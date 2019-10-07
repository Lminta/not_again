
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public DragAndDropItem item;
    public const int nItems = 4;
    public DragAndDropCell cell;
    private CanvasGroup canvasGroup;
    public DragAndDropCell[] playerInventory = new DragAndDropCell[nItems];
    public DragAndDropItem[] suffleArray = new DragAndDropItem[12];
    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        int r = Random.Range(0, 3);
        for (int i = 0; i < r; i++)
        {
            this.playerInventory[i].AddItem(Instantiate<DragAndDropItem>(suffleArray[Random.Range(0, 8)], this.transform)); // add random of items
        }
        if (this.gameObject.name != "PlayerInventory")
            this.Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setActive()
    {
        //Debug.Log(this.playerInventory);
        //this.playerInventory[0].gameObject.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            if (this.playerInventory[i] != null)
                Debug.Log("lol");// this.playerInventory[i].gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public DragAndDropItem[] get_inventory()
    {
        return (this.GetComponentsInChildren<DragAndDropItem>());
    }

    public void print_ll()
    {
        Debug.Log("lol");// this.playerInventory[i].gameObject.SetActive(false);

    }


}