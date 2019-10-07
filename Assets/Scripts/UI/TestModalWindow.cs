using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour
{
    public ModalPanel modalPanel;

    private UnityAction rightAction;

    private UnityAction leftAction;

    public GameObject player;
    private void Awake()
    {
        //modalPanel = ModalPanel.Instance();
        rightAction = new UnityAction(testRight);
        leftAction = new UnityAction(testLeft);

    }
    public void TestModal()
    {
        modalPanel.Choice("Hello, you have been attackted by wolfs", leftAction, rightAction);
    }

    void testRight()
    {
        Debug.Log("right");
    }

    void testLeft()
    {
        Debug.Log("butWhy?");
        player.GetComponent<PlayerController>().GetDmg(20);
    }
}
