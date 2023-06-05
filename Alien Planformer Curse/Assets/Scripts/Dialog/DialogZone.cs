using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogZone : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private int indexDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogManager.StartDialog(indexDialog);
        }
    }
}
