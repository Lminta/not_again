using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory playerInv;
    public GameObject start;
    private DragAndDropItem[] invItems;
    public bool winCondition = false;
    public PlayerController playerController;
    public ModalPanel modalPanel;
    public float space_ship = 0.0f;
    public int[] parts;
    private GameObject[] objects;

    private void Awake()
    {
     
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
        objects = GameObject.FindGameObjectsWithTag("Controller");
        if (objects.Length > 1)
        {
            Debug.Log("Destr");
            Destroy(this.gameObject);
        }

        start = GameObject.FindGameObjectWithTag("StartDesk");
        playerInv = start.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInv != null)
        {
            invItems = playerInv.get_inventory();
            //foreach(DragAndDropItem item in invItems)
            //{ 

            //}

            int rand = Random.Range(1, 3);
            if (playerController != null)
            {
                if (playerController.lifetime > 500 && (playerController.lifetime - rand) % 1500 == 0)
                {
                    this.GetComponent<EncWolves>().Exec();
                    Debug.Log(modalPanel);
                }
            }
            Debug.Log("invItem size: " + invItems.Length);
            if (invItems.Length > 2)
            {

                //Debug.Log(invItems[0].name);
                //Debug.Log(invItems[1].tag);
                //Debug.Log(invItems[2].tag);
                Debug.Log(invItems[0].name[invItems[0].name.Length - 8]);
                Debug.Log(invItems[1].name[invItems[1].name.Length - 8]);
                Debug.Log(invItems[2].name[invItems[2].name.Length - 8]);


                if (invItems[0].tag == "top" && invItems[1].tag == "middle" && invItems[2].tag == "bottom")
                {
                    parts = new int[5];
                    parts[0] =  invItems[0].name[invItems[0].name.Length - 8] - 48;
                    parts[1] = invItems[1].name[invItems[1].name.Length - 8] - 48;
                    parts[2] = invItems[2].name[invItems[2].name.Length - 8] - 48;
                    if (winCondition == false)
                    {
                        winCondition = true;
                        Debug.Log("Win");
                        SceneManager.LoadScene("minigame");
                    }
                }
            }

        }
    }
}
