using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mg_runner_s : MonoBehaviour
{
    private Rigidbody2D         rb2D;
    Vector2                     force = Vector2.zero;

    //ЭТА ПЕРЕМЕННАЯ ОТВЕЧАЕТ ЗА СЛОЖНОСТЬ, 1 -> ОЧЕНЬ СЛОЖНО | 10 -> ОЧЕНЬ ЛЕГКО
    public float                shake;

    float                       time = 0;
    //public Text                 speed_text;
    private float               speed;
    public EdgeCollider2D       outer_edge;
    public PolygonCollider2D    outer;
    public BoxCollider2D        inner;
    bool                        death;
    float                       death_timer;
    public Text                 death_text;
    public GameObject           rocket;
    public GameObject           rocket_scale;
    private GameObject[]        objs;
    private readonly float      EPSILON;

    //ANIMATION
    public GameObject           arena;
    public GameObject           smoke;
    public GameObject           scale;
    public GameObject           sky;
    SpriteRenderer              smoke_s;
    float                       time_main;
    float                       time_anim;
    public Sprite[]             s_sprites = new Sprite[6];
    bool                        takeof_done = false;
    bool                        anim_done = false;
    int                         takeof_count = 0;


    void Start()
    {
        time = Time.time;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("GetForce", 1, 0.5f);
        death_text.text = "";
        DrawSpeed();

        Vector2[] points = outer.points;
        outer_edge.points = points;
        Destroy(outer);

        smoke_s = smoke.GetComponent<SpriteRenderer>();
        time_main = Time.time;
        time_anim = time_main;
    }

    void Update()
    {
        if (!anim_done)
        {
            takeof_anim();
            if (System.Math.Abs(rocket.transform.position.y) < 0.1)
            {
                anim_done = true;
                time = Time.time;
            }
            else
            {
                Vector2 r_pos = rocket.transform.position;
                r_pos.y = Time.time - time_main - 2.5f;
                r_pos.x += Random.Range(0.02f * -1.0f, 0.02f);
                r_pos.y += Random.Range(0.02f * -1.0f, 0.02f);
                rocket.transform.position = r_pos;
            }
            if (System.Math.Abs(scale.transform.position.x + 9f) > 0.05)
            {
                Vector2 sc_pos = scale.transform.position;
                sc_pos.x += 0.05f;
                scale.transform.position = sc_pos;
            }
            if (System.Math.Abs(arena.transform.position.x - 7.8) > 0.05f)
            {
                Vector2 ar_pos = arena.transform.position;
                ar_pos.x -= 0.05f;
                arena.transform.position = ar_pos;
            }
        }
        else
        {
            Vector2 sky_pos = sky.transform.position;
            sky_pos.y -= 0.016f;
            sky.transform.position = sky_pos;
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
            if (Input.GetKey("space") || speed >= 100.0f)
            {
                //ЗДЕСЬ ОТПРАВИТЬ SPEED В GAME_CONTROLLER
                GameObject controller = GameObject.Find("GameController");
                GameController controller2 = controller.GetComponent<GameController>();
                controller2.winCondition = false;
                SceneManager.LoadScene("map", LoadSceneMode.Single);
            }
            rb2D.AddForce(force);
            DrawSpeed();
            ControlRocket();
            CheckDeath();
        }
    }

    void takeof_anim()
    {
        if (takeof_count > 5)
            takeof_done = true;
        if (Time.time - time_anim > 0.2f && !takeof_done)
        {
            time_anim = Time.time;
            smoke_s.sprite = s_sprites[takeof_count];
            takeof_count += 1;
        }
    }

    void ControlRocket()
    {
        Vector2 r_pos = new Vector2((rb2D.transform.position.x - 8.7f) * 2.5f, rb2D.transform.position.y * 2.0f);
        Vector3 r_rot = new Vector3(0, 0, rb2D.velocity.x * 0.2f);
        rocket.transform.Rotate(r_rot);
        rocket.transform.position = r_pos;
    }

    void ShakeRocket(float frc)
    {
        Vector2 r_pos = rocket.transform.position;
        r_pos.x += Random.Range(frc * -1.0f, frc);
        r_pos.y += Random.Range(frc * -1.0f, frc);
        rocket.transform.position = r_pos;
    }

    void GetForce()
    {
        int[] valid = new int[] { 1, -1 };
        if (!death && (rb2D.velocity.x > -0.5f && rb2D.velocity.x < 0.5f) &&
        (rb2D.velocity.y > -0.5f && rb2D.velocity.y < 0.5f))
        {
            force = new Vector2(valid[Random.Range(0, valid.Length)], valid[Random.Range(0, valid.Length)]) * (Time.time - time) / (6 * shake);
            //Debug.Log(force);
            //Debug.Log(Time.time - time);
        }
    }

    void CheckDeath()
    {
        if (speed >= 100.0f)
        {
            //ЗДЕСЬ ВЫЗВАТЬ СЦЕНУ ПОБЕДЫ
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
        if (death)
        {
            if (Time.time - death_timer < 3.0f)
            {
                //ЗДЕСЬ ВЫВЕСТИ ВАРНИНГ
                death_text.text = ">>>   Warning!   <<<\nPress 'space' to warp";
                ShakeRocket(0.1f);
            }
            else
            {
                //ЗДЕСЬ ВЫЗДВАТЬ СЦЕНУ ПРОИГРЫША
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        else
        {
            ShakeRocket(0.02f);
            death_text.text = "";
        }

    }

    void DrawSpeed()
    {
        speed = 100 / 30 * (Time.time - time);
        float pos_y = 2.46f / 100.0f * speed * 2;
        rocket_scale.transform.position = new Vector3(rocket_scale.transform.position.x, -2.46f + pos_y, 0);
        //speed_text.text = "Speed: " + speed.ToString() + "%";
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