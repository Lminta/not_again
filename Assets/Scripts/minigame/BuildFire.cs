using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFire : MonoBehaviour
{
    public Sprite[]             sprites = new Sprite[7];
    public SpriteRenderer       fireplace;
    float                       a_time = 0.0f;
    int                         cur = 0;

    void Update()
    {
        if (Time.time - a_time > 0.05f)
        {
            Debug.Log("FIREFIREFIRE   ->   " + cur);
            if (cur > 6)
                cur = 0;
            fireplace.sprite = sprites[cur];
            cur += 1;
            a_time = Time.time;
        }
    }
}
