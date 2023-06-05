using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBar : MonoBehaviour
{
    public Image handle;
    public Text amountText;

    public void UpdateImageBar(float amount, float maxAmount)
    {
        handle.fillAmount = amount / maxAmount;
        amountText.text = amount.ToString();
    }
}
