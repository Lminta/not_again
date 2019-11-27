using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    public GameObject Player;
    public PlayerController controller;
    public Vector3 destination;
    public GraphicRaycaster raycaster;
    // Start is called before the first frame update
    private GameObject destObj;
    private GameObject[] spawner;
    private GameObject[] gameObjects;
    private bool menuGTFO = false;
    AudioSource audioTest;
    private bool isplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        HideAllInv();
        audioTest = GetComponent<AudioSource>();
        controller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // check for canvas clicks
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);
            foreach (RaycastResult result in results)
            {
                if (result.gameObject && result.gameObject.CompareTag("Menu"))
                {
                    Debug.Log("GTFO");
                    menuGTFO = true;
                }
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && !hit.collider.gameObject.CompareTag("Player")
            && !hit.collider.gameObject.CompareTag("MapBorder") && !menuGTFO)
            {
                destination = hit.collider.gameObject.transform.position;
                CloseInventory();
                destObj = hit.collider.gameObject;
            }
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") && !menuGTFO)
                destination = Player.transform.position;
            if (hit.collider != null && !menuGTFO)
            {
                Debug.Log(hit.collider.gameObject.name);
                //if (hit.collider.gameObject.tag == "gotInventory")
                //{

                //    gameObjects = GameObject.FindGameObjectsWithTag("gotInventory");

                //    foreach (GameObject obj in gameObjects)
                //    {
                //        obj.GetComponentInChildren<CanvasGroup>().alpha = 0f;
                //        obj.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
                //    }
                //    hit.collider.GetComponentInChildren<CanvasGroup>().alpha = 1f;
                //    hit.collider.GetComponentInChildren<CanvasGroup>().blocksRaycasts = true;
                //}
                //else if (hit.collider.gameObject.name == "gotInventory")
                //{
                //    gameObjects = GameObject.FindGameObjectsWithTag("gotInventory");

                //    foreach (GameObject obj in gameObjects)
                //    {
                //        obj.GetComponentInChildren<CanvasGroup>().alpha = 0f;
                //        obj.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
                //    }
                //}
            }
            else if (!menuGTFO)
            {
                Debug.Log("SOSI BIBU");
                gameObjects = GameObject.FindGameObjectsWithTag("gotInventory");

                foreach (GameObject obj in gameObjects)
                {
                    obj.GetComponentInChildren<CanvasGroup>().alpha = 0f;
                    obj.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
                }
            }
            menuGTFO = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 distance = destination - Player.transform.position;
        //Debug.Log("DEST -> " + destination + " PLAYER -> "  + Player.transform.position);
        if (System.Math.Abs(distance.x) > 0.2 || System.Math.Abs(distance.y) > 0.2)
        {
            if (!isplaying)
            {
                audioTest.Play(0);
                isplaying = true;
            }
            controller.Movement(distance.normalized.x, distance.normalized.y);
        }
        else
        {
            if (!V3Equal(destination, Player.transform.position))
                OpenInventory();
            destination = Player.transform.position;
            isplaying = false;
            audioTest.Stop();
        }
    }

    public GameObject ClosestObj(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public bool V3Equal(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }

    void OpenInventory()
    {
        Debug.Log("GO -> " + destObj.name);
        if (destObj)
        {
            destObj.gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1f;
            destObj.gameObject.GetComponentInChildren<CanvasGroup>().blocksRaycasts = true;
        }
    }

    void CloseInventory()
    {
        if (destObj)
        {
            destObj.gameObject.GetComponentInChildren<CanvasGroup>().alpha = 0f;
            destObj.gameObject.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public bool CheckInvCell(RaycastHit2D hit)
    {
        Debug.Log("grandparent name -> " + hit.collider.gameObject.name);
        return (hit.collider.gameObject.name == "PlayerInventory");
    }

    public void HideAllInv()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("gotInventory");

        foreach (GameObject obj in gameObjects)
        {
            obj.GetComponentInChildren<CanvasGroup>().alpha = 0f;
            obj.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
        }
    }
}