using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mv_runner_s : MonoBehaviour
{
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb2D.AddForce(Vector2.up);
        }
        if (Input.GetKey("down"))
        {
            rb2D.AddForce(Vector2.down);
        }
        if (Input.GetKey("right"))
        {
            rb2D.AddForce(Vector2.right);
        }
        if (Input.GetKey("left"))
        {
            rb2D.AddForce(Vector2.left);
        }
    }
}
