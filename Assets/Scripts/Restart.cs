using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Restart : MonoBehaviour
{
    private GameObject[] objs;
    private float t_0;
    public Text respTime;
    // Start is called before the first frame update
    internal void Start()
    {
        //objs = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(objs[0]);
        //objs[0].gameObject.SetActive(false);
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
