using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Restart : MonoBehaviour
{
    private float t_0;
    public Text respTime;

    internal void Start()
    {
        t_0 = Time.time;
    }

    void Update()
    {
        float t_1 = Time.time - t_0;
        if (t_1 <= 5)
            respTime.text = "Respawn time is " + (5 - t_1);
        else
            respTime.text = "Press any key";
        if (Input.anyKey && t_1 > 5)
            SceneManager.LoadScene("map", LoadSceneMode.Single);
    }
}
