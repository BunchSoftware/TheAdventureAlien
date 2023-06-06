using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] point;
    [SerializeField] private float speed;
    [SerializeField] private float waitTime = 3f;
    private bool CanGo = true;
    private int indexPoint = 0;

    public delegate void ReachedThePoint();
    public event ReachedThePoint OnReachedThePoint;

    private void Update()
    {
        if (point.Length >= 2)
        {
            if (CanGo)
                transform.position = Vector3.MoveTowards(transform.position, point[indexPoint].position, speed * Time.deltaTime);

            if (transform.position == point[indexPoint].position)
            {
                if (indexPoint < point.Length - 1)
                    indexPoint++;
                else
                    indexPoint = 0;
                CanGo = false;
                StartCoroutine(WaitingIE());
            }
        }
    }
    private IEnumerator WaitingIE()
    {
        yield return new WaitForSeconds(waitTime);
        OnReachedThePoint?.Invoke();
        CanGo = true;
    }
}
