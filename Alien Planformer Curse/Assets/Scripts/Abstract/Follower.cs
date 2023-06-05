using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower: MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform target;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private Transform downLimit;
    [SerializeField] private Transform upLimit;
    private float _xOfsetClamp;
    private float _yOfsetClamp;
    private Vector3 position;

    private Vector2[] pathMin;
    private Vector2[] pathMax;

    private void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y,transform.position.z);
        _xOfsetClamp = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.nearClipPlane)).x - Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Camera.main.nearClipPlane)).x;
        _yOfsetClamp = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, Camera.main.nearClipPlane)).y - Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane)).y;
    }

    //private Vector2[] SortPathMax(Vector2[] pathMax)
    //{
    //    for (var i = 1; i < pathMax.Length; i++)
    //    {
    //        for (var j = 0; j < pathMax.Length - i; j++)
    //        {
    //            if (pathMax[j].x > pathMax[j++].x & pathMax[j].y > pathMax[j++].y)
    //            {
    //                Swap(ref pathMax[j], ref pathMax[j++]);
    //            }
    //        }
    //    }
    //    return pathMax;
    //}
    ////private static Book[] SortBooksToABCMin(Book[] library)
    ////{
    ////    for (int i = 1; i < library.Length; i++)
    ////    {
    ////        for (int j = 0; j < library.Length - i; j++)
    ////        {
    ////            if (String.Compare(library[j].Name, library[j + 1].Name) < 0)
    ////            {

    ////                Swap(ref library[j], ref library[j++]);
    ////            }
    ////        }
    ////    }
    ////    return library;
    ////}
    //private static void Swap <T> (ref T value1, ref T value2)
    //{
    //    (value1, value2) = (value2, value1);
    //}

    private void FixedUpdate()
    {
        position = new Vector3
        {
            x = target.position.x,
            y = target.position.y,
            z = transform.position.z
        };
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

        transform.position = new Vector3
               (
               Mathf.Clamp(transform.position.x, leftLimit.transform.position.x + _xOfsetClamp, rightLimit.transform.position.x - _xOfsetClamp),
               Mathf.Clamp(transform.position.y, downLimit.transform.position.y + _yOfsetClamp, upLimit.transform.position.y - _yOfsetClamp),
               transform.position.z
               );

        //for (int i = 0; i < Bounds.points.Length; i++)
        //{
        //    for (int j = 0; j < Bounds.pathCount; j++)
        //    {
        //        for (int y = 0; y < Bounds.GetPath(j).Length; y++)
        //        {
        //            transform.position = new Vector3
        //      (
        //      Mathf.Clamp(transform.position.x, Bounds.GetPath(j)[y].x + _xOfsetClamp, Bounds.GetPath(j)[y++].x - _xOfsetClamp),
        //      Mathf.Clamp(transform.position.y, Bounds.GetPath(j)[y].y + _yOfsetClamp, Bounds.GetPath(j)[y++].y - _yOfsetClamp),
        //      transform.position.z
        //      );

        //        }
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(leftLimit.position.x, upLimit.position.y), new Vector2(rightLimit.position.x, upLimit.position.y));
        Gizmos.DrawLine(new Vector2(leftLimit.position.x, downLimit.position.y), new Vector2(rightLimit.position.x, downLimit.position.y));
        Gizmos.DrawLine(new Vector2(leftLimit.position.x, upLimit.position.y), new Vector2(leftLimit.position.x, downLimit.position.y));
        Gizmos.DrawLine(new Vector2(rightLimit.position.x, upLimit.position.y), new Vector2(rightLimit.position.x, downLimit.position.y));
    }
}
