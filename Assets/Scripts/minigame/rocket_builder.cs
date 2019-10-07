using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_builder : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[9];
    public GameObject r_top;
    public GameObject r_mid;
    public GameObject r_bot;


    //ЭТИМ ТРЕМ ИНТАМ НАДО ВЫДАТЬ ЗНАЧЕНИЯ ОТ 0 ДО 2
    public int top = 0;
    public int mid = 0;
    public int bot = 0;

    void Start()
    {
        SpriteRenderer s_top = r_top.GetComponent<SpriteRenderer>();
        SpriteRenderer s_mid = r_mid.GetComponent<SpriteRenderer>();
        SpriteRenderer s_bot = r_bot.GetComponent<SpriteRenderer>();

        s_top.sprite = sprites[top];
        s_mid.sprite = sprites[mid + 3];
        s_bot.sprite = sprites[bot + 6];
    }
}
