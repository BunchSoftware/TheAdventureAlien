using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialog
{
    public PartnerDialog partnerDialog;
    public DropEnum enterDrop;
    public DropEnum exitDrop;
    public string Sentences;
    public float waitSecond;
    public bool isFade = false;
}
