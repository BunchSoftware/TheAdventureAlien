using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Patrol
{
    private bool FlipX = false;

    private void Start()
    {
        OnReachedThePoint += Flip;
    }
    private void Flip()
    {
        if (FlipX == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            FlipX = true;
        }
        else if (FlipX)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            FlipX = false;
        }
    }
}
