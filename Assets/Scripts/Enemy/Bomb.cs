using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthModule>().RecountHealth(-Damage);
            Destroy(gameObject);
        }
    }
}
