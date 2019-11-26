using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Camera;
    public Click cl;
    public Text LifeTimeText; 
    public float speed;
    public int lifetime;
    public float EPSILON = 0.001f;
    private float t_0;
    private GameObject[] gameObjects;
    void Start()
    {
        cl = Camera.GetComponent<Click>();
    }

    void FixedUpdate()
    {
        //TryToMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        CheckTime();
    }

    void TryToMove(float moveHorizontal, float moveVertical)
    {
        if (System.Math.Abs(moveHorizontal) > EPSILON || System.Math.Abs(moveVertical) > EPSILON)
        {
            var vec = new Vector3(moveHorizontal, moveVertical, 0);
            Movement(vec.normalized.x, vec.normalized.y); 
            cl.destination = this.transform.position;
        }

    }

    public void Movement(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(transform.position.x + moveHorizontal * speed,
        transform.position.y + moveVertical * speed,
        transform.position.z);

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

    public  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MapBorder"))
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        //if (other.gameObject.CompareTag("gotInventory"))
        //{
        //    gameObjects = GameObject.FindGameObjectsWithTag("gotInventory");

        //    foreach (GameObject obj in gameObjects)
        //    {
        //        obj.GetComponentInChildren<CanvasGroup>().alpha = 0f;
        //        obj.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
        //    }
        //    other.gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1f;
        //    other.gameObject.GetComponentInChildren<CanvasGroup>().blocksRaycasts = true;
        //}
        //else if (other.gameObject.CompareTag("gotInventory"))
        //{
        //    gameObjects = GameObject.FindGameObjectsWithTag("gotInventory");

        //    foreach (GameObject obj in gameObjects)
        //    {
        //        obj.GetComponentInChildren<CanvasGroup>().alpha = 0f;
        //        obj.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
        //    }
        //}

     }


    public  void GetDmg( int dmg)
    {
        this.lifetime -= dmg;
    }
}
