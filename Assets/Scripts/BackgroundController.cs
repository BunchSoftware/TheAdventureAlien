using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField][Range(0f, 1f)] private float parallaxStrength = 0.1f;
    private Vector3 targetPreviousPosition;

    private void Start()
    {
        if (!target)
            target = Camera.main.transform;

        targetPreviousPosition = target.position;
    }
    private void Update()
    {
        target = Camera.main.transform;

        Vector3 delta = target.position  - targetPreviousPosition;

        targetPreviousPosition = target.position;


        transform.position += delta * parallaxStrength;
    }
}

