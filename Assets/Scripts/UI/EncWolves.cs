using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EncWolves : MonoBehaviour
{
    public ModalPanel       modalPanel;
    private UnityAction     rightAction;
    private UnityAction     leftAction;
    public GameObject       player;
    public Text             t_left;
    public Text             t_right;

    private void Awake()
    {
        rightAction = new UnityAction(actRight);
        leftAction = new UnityAction(actLeft);
        t_left.text = "Fight back!";
        t_right.text = "Run! Run! Run!";

    }

    public void Exec()
    {
        string  msg = "";
        int     fate = 0;

        fate = Random.Range(0, 2);
        if (fate == 0)
        {
            msg =   "As you carve your way through rust and filth of the Old World, " +
                    "a pack of wild dogs crosses your path! They look quite delighted " +
                    "to have finally found such a rare treat...";
        }
        else if (fate == 1)
        {
            msg =   "You make a stop to take some rest from driving and check the state of your trusty vehicle's parts. " +
            	    "As you fiddle with the insides of your only friend and hope for survival, " +
            	    "a swarm of radroaches crawls out of a nearby pile of trash. " +
            	    "It seems that they are quite interested in what you are doing. Or specifically in you.\nRadroaches are hard to read...";
        }
        modalPanel.Choice(msg, leftAction, rightAction);
    }

    void actRight()
    {
        //to do: if player has a knife, dmg == 0, else dmg == 40
        player.GetComponent<PlayerController>().GetDmg(0);
    }

    void actLeft()
    {
        player.GetComponent<PlayerController>().GetDmg(20);
    }
}