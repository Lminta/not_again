using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory playerInv;
    private DragAndDropItem[] invItems;
    private bool winCondition = false;
    public PlayerController playerController;
    public ModalPanel modalPanel;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
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
            if (playerController.lifetime > 500 && (playerController.lifetime - rand) % 500 == 0)
            {
                this.GetComponent<EncWolves>().Exec();
                Debug.Log(modalPanel);
            }
        }
        if (invItems.Length > 3) {

            if (invItems[0].tag == "top" && invItems[1].tag == "middle" && invItems[0].tag == "bottom")
            {
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
