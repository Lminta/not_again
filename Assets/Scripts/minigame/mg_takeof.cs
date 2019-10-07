using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mg_takeof : MonoBehaviour
{
    public GameObject   smoke;
    SpriteRenderer      smoke_s;
    float               time_main;
    float               time_anim;
    public Sprite[]     s_sprites = new Sprite[6];
    int                 s_count = 0;
    bool                done = false;

    void Start()
    {
        smoke_s = smoke.GetComponent<SpriteRenderer>();
        time_main = Time.time;
        time_anim = time_main;
        //Debug.Log(smoke_s);
    }

    private void Update()
    {
        smoke_anim();
    }

    void smoke_anim()
    {
        if (s_count > 5)
        done = true;
        if (Time.time - time_anim > 0.2f)
        {
            time_anim = Time.time;
            smoke_s.sprite = s_sprites[s_count];
            s_count += 1;
        }
    }
}
