using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public GameObject frame;
    // Start is called before the first frame update
    void Start()
    {
        frame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        frame.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        frame.gameObject.SetActive(false);
    }
}
