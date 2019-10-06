using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject Player;
    public PlayerController controler;
    public Vector3 destination;
    // Start is called before the first frame update
    AudioSource audioTest;
    private bool isplaying = false;
    void Start()
    {
        audioTest = GetComponent<AudioSource>();
        controler = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && !hit.collider.gameObject.CompareTag("Player")
            && !hit.collider.gameObject.CompareTag("MapBorder"))
                destination = hit.collider.gameObject.transform.position;
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                destination = Player.transform.position;
                Debug.Log(hit.collider.gameObject.name);
            }
        }

        Vector3 distance = destination - Player.transform.position;
        if (System.Math.Abs(distance.x) > 0.2 || System.Math.Abs(distance.y) > 0.2)
        {
            if (!isplaying)
            {
                audioTest.Play(0);
                isplaying = true;
            }
            controler.Movement(distance.normalized.x, distance.normalized.y);
        }
        else
        {
            isplaying = false;
            audioTest.Stop();
        }
    }
}
