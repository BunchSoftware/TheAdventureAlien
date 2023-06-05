using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnockoutBlock : MonoBehaviour
{
    [SerializeField] private Sprite knockoutedSprite;
    [SerializeField] private float secondForDrop;
    [SerializeField] private float speedDrop;
    [SerializeField] private GameObject drop;
    [SerializeField] private Transform targetDrop;
    private bool isKnockout = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<MusicManager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isKnockout == false)
        {
            musicManager.OnPlayOneShot(2);
            isKnockout = true;
            StartCoroutine(KnockoutIE());
        }
    }
    private IEnumerator KnockoutIE()
    {
        float time = 0;
        if (drop != null)
        {
            GameObject gameObject = Instantiate(drop, transform.position, transform.rotation);
            while (time <= secondForDrop)
            {
                time += Time.deltaTime;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetDrop.position, speedDrop * Time.deltaTime); ;
            }
        }
        spriteRenderer.sprite = knockoutedSprite;
        yield return null;
    }
}
