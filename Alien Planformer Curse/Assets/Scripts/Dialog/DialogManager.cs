using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogueWindow dialogueWindowPlayer;
    [SerializeField] private DialogueWindow dialogueWindowNPC;
    [SerializeField] private float speedText;
    [SerializeField] private GameObject groupCanvas;
    [SerializeField] private GameObject canvasDialog;
    [SerializeField] private UIController uIController;
    [SerializeField] private int currentIndexScene;
    private DialogueScript dialogueScript;

    private void Start()
    {
        dialogueScript = GetComponent<DialogueScript>();
    }

    public void StartDialog(int indexDialogPoint)
    {
        canvasDialog.SetActive(true);
        groupCanvas.SetActive(false);
        uIController.playerController.enabled = false;
        uIController.playerController.ZeroPhysic();
        TypeLine(dialogueScript.dialogPoints[indexDialogPoint]);
    }
    private void EndDialog()
    {
        canvasDialog.SetActive(false);
        groupCanvas.SetActive(true);
        uIController.playerController.enabled = true;
    }

    

    public void TypeLine(DialogPoint dialogPoint)
    {
        StartCoroutine(TypeLineIE(dialogPoint));
    }

    IEnumerator TypeLineIE(DialogPoint dialogPoint)
    {
        for (int i = 0; i < dialogPoint.dialog.Count; i++)
        {
            EnterDrop(dialogPoint.dialog[i]);
            DialogueWindow dialogueWindow = WhoseDialog(dialogPoint.dialog[i]);
            dialogueWindow.Header.sprite = dialogPoint.dialog[i].partnerDialog.Head;
            dialogueWindow.textName.text = dialogPoint.dialog[i].partnerDialog.Name;
            dialogueWindow.textDialog.text = null;
            for (int j = 0; j < dialogPoint.dialog[i].Sentences.ToCharArray().Length; j++)
            {
                dialogueWindow.textDialog.text += dialogPoint.dialog[i].Sentences[j];
                yield return new WaitForSeconds(speedText);
            }
            yield return new WaitForSeconds(dialogPoint.dialog[i].waitSecond);
            ExitDrop(dialogPoint.dialog[i]);

            if (dialogPoint.dialog[i].isFade)
            {
                uIController.fade.currentIndexScene = currentIndexScene;
                uIController.fade.FadeBlack();
            }

            if (i == dialogPoint.dialog.Count - 1)
                EndDialog();
        }      
    }

    private void EnterDrop(Dialog dialog)
    {
        switch (dialog.enterDrop)
        {
            case DropEnum.DropDown:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropDown();
                    else
                        dialogueWindowNPC.DropDown();
                }
                break;

            case DropEnum.DropUp:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropUp();
                    else
                        dialogueWindowNPC.DropUp();
                }
                break;
            case DropEnum.DropRight:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropRight();
                    else
                        dialogueWindowNPC.DropRight();
                }
                break;
            case DropEnum.DropLeft:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropLeft();
                    else
                        dialogueWindowNPC.DropLeft();
                }
                break;
        }
    }
    private void ExitDrop(Dialog dialog)
    {
        switch (dialog.exitDrop)
        {
            case DropEnum.DropDown:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropDown();
                    else
                        dialogueWindowNPC.DropDown();
                }
                break;

            case DropEnum.DropUp:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropUp();
                    else
                        dialogueWindowNPC.DropUp();
                }
                break;
            case DropEnum.DropRight:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropRight();
                    else
                        dialogueWindowNPC.DropRight();
                }
                break;
            case DropEnum.DropLeft:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropLeft();
                    else
                        dialogueWindowNPC.DropLeft();
                }
                break;
        }
    }
    private DialogueWindow WhoseDialog(Dialog dialog)
    {
        if (dialog.partnerDialog.gameObject.tag == "Player")
            return dialogueWindowPlayer;
        else
            return dialogueWindowNPC;
    }
}
