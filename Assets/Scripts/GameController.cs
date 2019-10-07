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
    private bool winCondition = false;
    public PlayerController playerController;
    public ModalPanel modalPanel;
    public float space_ship = 0.0f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        start = GameObject.FindGameObjectWithTag("StartDesk");
        playerInv = start.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        invItems =  playerInv.get_inventory();
        //foreach(DragAndDropItem item in invItems)
        //{ 

        //}
        int rand = Random.Range(1, 3);
        if (playerController != null)
        {
            if (playerController.lifetime > 50 && (playerController.lifetime - rand) % 200 == 0)
            {
                this.GetComponent<EncWolves>().Exec();
                Debug.Log(modalPanel);
            }
        }

        if (invItems.Length > 3 & winCondition == false) {
            winCondition = true;
            Debug.Log("Win");
            SceneManager.LoadScene("minigame");
        }
    }
}
