using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mv_runner_s : MonoBehaviour
{
    private Rigidbody2D rb2D;
    Vector2 shake = Vector2.zero;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("Shaking", 3, 1);
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb2D.AddForce(Vector2.up * 1.5f);
        }
        if (Input.GetKey("down"))
        {
            rb2D.AddForce(Vector2.down * 1.5f);
        }
        if (Input.GetKey("right"))
        {
            rb2D.AddForce(Vector2.right * 1.5f);
        }
        if (Input.GetKey("left"))
        {
            rb2D.AddForce(Vector2.left * 1.5f);
        }
        rb2D.AddForce(shake);
    }

    void Shaking()
    {
        //shake = new Vector2(0.5f, 0.5f);
        shake = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f) * Time.time / 5.0f);
        if (shake.x > 1.0f || shake.x < -1.0f)
        {
            shake.x = shake.x < 0 ? -1.0f : 1.0f;
        }
        if (shake.y > 1.0f || shake.y < -1.0f)
        {
            shake.y = shake.y < 0 ? -1.0f : 1.0f;
        }
        Debug.Log(shake);
    }
}
