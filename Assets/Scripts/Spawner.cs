
using System.Collections.Generic;
using System.Collections;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    public List<GameObject> stationsPrefabs = new List<GameObject>();
    public List<GameObject> debrisPrefabs = new List<GameObject>();
    public PlayerController con;
    public float difficult = 1;
    public GameObject Player;
    public int amountSites = 50;

    public List<GameObject> Result = new List<GameObject>();
    public float EPSILON { get; private set; }

    private GameObject[] objs;

    private void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Player");
        SpawnPlayer();
        if (objs.Length != 0)
            con = objs[0].GetComponent<PlayerController>();
        SpawnSites();
        //SpawnStations();
    }

    private bool CheckNeighbours(Vector3 ranVec)
    {
        int             index = 0;
        BoxCollider2D   c_col;

        while (index < Result.Count)
        {
            c_col = Result[index].GetComponent<BoxCollider2D>();
            if (c_col.bounds.Contains(ranVec))
                return (true);
            index += 1;
        }
        return (false);
    }

    public void SpawnSites()
    {
        float border = 5000;
        for (int i = 0; i < amountSites; i++)
        {
            float x = 8 * Random.Range(-border, border) / 5000f;
            //if (x > 0)
            //    x = x - i * 0.1f;
            //else
                //x = x + i * 0.1f;
            float y = Random.Range(-border, border) / 1200f;
            GameObject prefab = debrisPrefabs[Random.Range(0, debrisPrefabs.Count)];
            var ranVec = new Vector3(x, y, 1);
            if (System.Math.Abs(ranVec.x) > EPSILON && System.Math.Abs(ranVec.y) > EPSILON && !CheckNeighbours(ranVec))
            {
                prefab.transform.position = ranVec;
                Result.Add(Instantiate(prefab, ranVec, prefab.transform.rotation));
            }
            else
                i--;
        }
        CheckObject();
    }

    public void SpawnStations()
    {
        GameObject start = GameObject.Find("StartDesk");
        float border = con.lifetime * difficult;
        if (border > 5000)
            border = 5000;
        for (int i = 0; i < stationsPrefabs.Count; i++)
        {
            float x = 8 * Random.Range(-border, border) / 5000f;
            float y = Random.Range(-border, border) / 1200f;
            GameObject prefab = stationsPrefabs[i];
            //if (prefab.CompareTag("StartDesk") && start != null)
                //continue;
            var ranVec = new Vector3(x, y, 1);
            prefab.transform.position = ranVec;

            Result.Add(Instantiate(prefab, ranVec, prefab.transform.rotation));
        }
    }

    public void SpawnPlayer()
    {
        if (objs.Length == 0)
        {
            var ranVec = Vector3.zero;
            Player = Instantiate(Player, ranVec, Player.transform.rotation);
        }
        else
        {
            objs[0].gameObject.SetActive(true);
            var ranVec = Vector3.zero;
            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            objs[0].transform.position = ranVec;
        }
    }

    void CheckObject()
    {
        float border = con.lifetime * difficult;
        for (int i = 0; i < Result.Count; i++)
        {
            if (System.Math.Abs(Result[i].transform.position.x) > 8 * border / 5000f ||
            System.Math.Abs(Result[i].transform.position.y) > border / 1200)
                Result[i].gameObject.SetActive(false);
        }
    }
}