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
        if (invItems.Length > 3 & winCondition == false) {
            winCondition = true;
            Debug.Log("Win");
            SceneManager.LoadScene(4);
        }
    }
}
