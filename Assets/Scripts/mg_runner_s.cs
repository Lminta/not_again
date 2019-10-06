﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mg_runner_s : MonoBehaviour
{
    private Rigidbody2D         rb2D;
    Vector2                     force = Vector2.zero;
    float                       shake = 1.0f;
    float                       time = 0;
    public Text                 speed_text;
    private float               speed;
    public EdgeCollider2D       outer_edge;
    public PolygonCollider2D    outer;
    public CircleCollider2D     inner;
    bool                        death;
    float                       death_timer;
    public Text                 death_text;
    public GameObject           rocket;
    private readonly float      EPSILON;

    void Start()
    {
        time = Time.time;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("GetForce", 1, 0.5f);
        speed_text.text = "";
        death_text.text = "";
        DrawSpeed();

        Vector2[] points = outer.points;
        outer_edge.points = points;
        Destroy(outer);
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb2D.AddForce(Vector2.up * 2f);
        }
        if (Input.GetKey("down"))
        {
            rb2D.AddForce(Vector2.down * 2f);
        }
        if (Input.GetKey("right"))
        {
            rb2D.AddForce(Vector2.right * 2f);
        }
        if (Input.GetKey("left"))
        {
            rb2D.AddForce(Vector2.left * 2f);
        }
        rb2D.AddForce(force);
        DrawSpeed();
        ControlRocket();
        CheckDeath();
    }

    void ControlRocket()
    {
        Vector2 r_pos = new Vector2(rb2D.transform.position.x * 3.0f, rb2D.transform.position.y + 5.0f);
        rocket.transform.position = r_pos;
    }

    void GetForce()
    {
        int[] valid = new int[] { 1, -1 };
        if (!death && (rb2D.velocity.x > -0.3f && rb2D.velocity.x < 0.3f) &&
        (rb2D.velocity.y > -0.3f && rb2D.velocity.y < 0.3f))
        {
            force = new Vector2(valid[Random.Range(0, valid.Length)], valid[Random.Range(0, valid.Length)]) * (Time.time - time) / (5 * 4);
            Debug.Log(force);
            Debug.Log(Time.time - time);
        }
    }

    void CheckDeath()
    {
        Vector2 r_pos = rocket.transform.position;
        if (death)
        {
            if (Time.time - death_timer < 3.0f)
            {
                death_text.text = ">>>Warning!<<<";
                r_pos.x += Random.Range(-0.1f, 0.1f);
                r_pos.y += Random.Range(-0.1f, 0.1f);
                rocket.transform.position = r_pos;
            }
            else
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        else
        {
            death_text.text = "";
        }

    }

    void DrawSpeed()
    {
        speed = 100 / 30 * Time.time - time;
        speed_text.text = "Speed: " + speed.ToString() + "%";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == inner)
        {
            death = true;
            death_timer = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision = inner)
        {
            death = false;
            death_timer = Time.time;
        }
    }
}