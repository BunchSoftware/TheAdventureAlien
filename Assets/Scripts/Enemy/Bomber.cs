using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject prefabBomb;
    [SerializeField] private Transform pointShot;
    private EnemyPatrol enemyPatrol;
    private Enemy enemy;
    private bool isDead;

    private void Start()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
        enemy = GetComponent<Enemy>();
        enemyPatrol.OnReachedThePoint += EnemyPatrol_OnReachedThePoint;
        enemy.healthModule.OnDied += HealthModule_OnDied;
    }

    private void HealthModule_OnDied()
    {
        isDead = true;
    }

    private void EnemyPatrol_OnReachedThePoint()
    {
        if (isDead == false)
            Shot();
    }
  

    public void Shot()
    {
        Instantiate(prefabBomb, pointShot.position, pointShot.rotation);
    }
}
