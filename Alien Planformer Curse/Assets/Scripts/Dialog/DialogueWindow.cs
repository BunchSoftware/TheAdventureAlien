using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    public TextMeshProUGUI textDialog;
    public Text textName;
    public Image Header;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void DropRight()
    {
        gameObject.SetActive(true);
        animator.SetInteger("State", 4);
    }
    public void DropLeft()
    {
        gameObject.SetActive(true);
        animator.SetInteger("State", 3);
    }
    public void DropDown()
    {
        animator.SetInteger("State", 1);
    }
    public void DropUp()
    {
        gameObject.SetActive(true);
        animator.SetInteger("State", 2);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
