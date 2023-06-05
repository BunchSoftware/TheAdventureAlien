using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject prefabBomb;
    [SerializeField] private Transform pointShot;
    private EnemyPatrol enemyPatrol;

    private void Start()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
        enemyPatrol.OnReachedThePoint += EnemyPatrol_OnReachedThePoint;
    }

    private void EnemyPatrol_OnReachedThePoint()
    {       
        Shot();
    }
  

    public void Shot()
    {
        Instantiate(prefabBomb, pointShot.position, pointShot.rotation);
    }
}
