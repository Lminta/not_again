
using System.Collections.Generic;
using System.Collections;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    public List<GameObject> stationsPrefabs = new List<GameObject>();
    public List<GameObject> debrisPrefabs = new List<GameObject>();
    public GameObject Player;
    public int amountSites = 20;

    public float EPSILON { get; private set; }

    private void Start()
    {
        SpawnSites();
        SpawnStations();
        SpawnPlayer();
    }

    public void SpawnSites()
    {
        for (int i = 0; i < amountSites; i++)
        {
            GameObject prefab = debrisPrefabs[Random.Range(0, debrisPrefabs.Count)];
            var ranVec = new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 1);
            if (System.Math.Abs(ranVec.x) > EPSILON && System.Math.Abs(ranVec.y) > EPSILON)
            {
                prefab.transform.position = ranVec;
                Instantiate(prefab, ranVec, prefab.transform.rotation);
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
            var ranVec = new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 1);
            prefab.transform.position = ranVec;
            Instantiate(prefab, ranVec, prefab.transform.rotation);
        }
    }

    public void SpawnPlayer()
    {
        var ranVec = Vector3.zero;
        Instantiate(Player, ranVec, Player.transform.rotation);
    }
 }