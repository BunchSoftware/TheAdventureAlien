using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstiateObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject gameObject;


    private void OnEnable()
    {
        gameObject = Instantiate(prefab, transform.position, transform.rotation);
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
