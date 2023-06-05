using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float DamageOnTouch;
    [SerializeField] private float DamageMe;
    [SerializeField] private int ScoreOnMurder;
    [SerializeField] private HealthModule healthModule;
    [SerializeField] private float deathTime = 2f;
    private bool isHit = false;
    [SerializeField] private GameObject drop;
    [SerializeField] private Impulse impulse;
    [SerializeField] private MusicManager musicManager;

    private Rigidbody2D rigidbody2D;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private EnemyPatrol enemyPatrol;

    private PlayerController lastAttackPlayer;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
        healthModule.OnDied += HealthModule_OnDied;
    }

    private void HealthModule_OnDied()
    {
        StartCoroutine(DeathIE());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isHit == false)
        {
            lastAttackPlayer = collision.gameObject.GetComponent<PlayerController>();
            collision.gameObject.GetComponent<HealthModule>().RecountHealth(-DamageOnTouch);
            healthModule.RecountHealth(-DamageMe);
        }

    }
    private IEnumerator DeathIE()
    {
        if(drop != null)
            Instantiate(drop, transform.position,Quaternion.identity);
         impulse.gameObject.SetActive(false);

        isHit = true;
        musicManager.OnPlayOneShotAndEndLast(0);
        animator.SetBool("isDeath", true);
        spriteRenderer.sortingOrder = 5;
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        collider2D.enabled = false;
        lastAttackPlayer.RecountScore(ScoreOnMurder);

        
        yield return new WaitForSeconds(deathTime);
        for (int i = 0; i < enemyPatrol.point.Length; i++)
        {
            Destroy(enemyPatrol.point[i].gameObject);
        }
        Destroy(gameObject);
    }
}
