using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModalPanel : MonoBehaviour
{
    public Text question;
    public Image icon;
    public Button leftButton;
    public Button rightButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if(!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.Log("No modalPanel on the scene");
             
        }

        return modalPanel;
    }


    public void Choice(string question, UnityAction leftEvent, UnityAction rightEvent)
    {
        modalPanelObject.SetActive(true); 
        leftButton.onClick.RemoveAllListeners();
        leftButton.onClick.AddListener(leftEvent);
        leftButton.onClick.AddListener(ClosePanel);
        rightButton.onClick.RemoveAllListeners();
        rightButton.onClick.AddListener(rightEvent);
        rightButton.onClick.AddListener(ClosePanel);
        this.question.text = question;
        this.icon.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);

    }

    public void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
