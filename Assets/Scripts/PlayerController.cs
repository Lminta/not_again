using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Text LifeTimeText; 
    public float speed;
    public int lifetime;
    public float EPSILON { get; private set; }

    private float t_0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        CheckTime();
    }

    public void Movement(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(transform.position.x + moveHorizontal * speed,
        transform.position.y + moveVertical * speed,
        transform.position.z);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if (System.Math.Abs(moveHorizontal) > EPSILON || System.Math.Abs(moveVertical) > EPSILON)
            lifetime--;
        transform.position = movement;
    }

    void CheckTime()
    {
        LifeTimeText.text = "Oxygen " + lifetime.ToString();
        if (lifetime == 0)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("MapBorder"))
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
