using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_builder : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[9];
    public GameObject r_top;
    public GameObject r_mid;
    public GameObject r_bot;
    public mg_runner_s runner;

    //ЭТИМ ТРЕМ ИНТАМ НАДО ВЫДАТЬ ЗНАЧЕНИЯ ОТ 0 ДО 2
    public int top = 0;
    public int mid = 0;
    public int bot = 0;

    void Start()
    {
        GameObject controller = GameObject.Find("GameController");
        SpriteRenderer s_top = r_top.GetComponent<SpriteRenderer>();
        SpriteRenderer s_mid = r_mid.GetComponent<SpriteRenderer>();
        SpriteRenderer s_bot = r_bot.GetComponent<SpriteRenderer>();
        GameController controller2 = controller.GetComponent<GameController>();
        Debug.Log("BUILd");
        Debug.Log(controller2.parts[0]);
        Debug.Log(controller2.parts[1]);
        Debug.Log(controller2.parts[2]);
        if(controller2.parts[0] == controller2.parts[1] && controller2.parts[1] == controller2.parts[2])
        {
            runner.shake = 8;
        }
        s_top.sprite = sprites[controller2.parts[0]];
        s_mid.sprite = sprites[controller2.parts[1] + 3];
        s_bot.sprite = sprites[controller2.parts[2] + 6];
    }
}
