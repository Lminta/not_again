
using System.Collections.Generic;
using System.Collections;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    public List<GameObject> stationsPrefabs = new List<GameObject>();
    public List<GameObject> debrisPrefabs = new List<GameObject>();
    public GameObject Player;
    public int amountSites = 20;

    public List<GameObject> Result = new List<GameObject>();
    public float EPSILON { get; private set; }

    private GameObject[] objs;

    private void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Player");
        SpawnSites();
        SpawnStations();
        SpawnPlayer();
    }

    public void SpawnSites()
    {
        for (int i = 0; i < amountSites; i++)
        {
            GameObject prefab = debrisPrefabs[Random.Range(0, debrisPrefabs.Count)];
            var ranVec = new Vector3(Random.Range(-9000, 9000) / 1000f, 
            Random.Range(-5000, 5000) / 1000f, 1);
            if (System.Math.Abs(ranVec.x) > EPSILON && System.Math.Abs(ranVec.y) > EPSILON)
            {
                prefab.transform.position = ranVec;
                Result.Add(Instantiate(prefab, ranVec, prefab.transform.rotation));
            }
            else
                i--;
        }
    }

    public void SpawnStations()
    {
        for (int i = 0; i < stationsPrefabs.Count; i++)
        { 
        GameObject prefab = stationsPrefabs[i];
            var ranVec = new Vector3(Random.Range(-9000, 9000) / 1000f,
            Random.Range(-5000, 5000) / 1000f, 1);
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
 }