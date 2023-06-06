using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    [SerializeField] private float impulse;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(impulse * Vector2.up, ForceMode2D.Impulse);
        }
    } 
}

