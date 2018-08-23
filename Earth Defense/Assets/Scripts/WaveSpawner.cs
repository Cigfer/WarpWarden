using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject PrefabToSpawn = null;
    public GameObject GoalToGive = null;
    public float DelayOffset = 0f;

    public int MaxToSpawn = 10;

    public float TimeBetweenSpawn = 5f;
    private float LastTimeSpawned = 0f;

    private List<GameObject> SpawnedObjects;
	// Use this for initialization
	void Start () {
        SpawnedObjects = new List<GameObject>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (SpawnedObjects.Count < MaxToSpawn && LastTimeSpawned + TimeBetweenSpawn < Time.time - DelayOffset)
	    {
	        SpawnEnemyType1();
	    }
	}

    void SpawnEnemyType1()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y += (Random.value * 4f) - 2;
        GameObject spawned = Instantiate(PrefabToSpawn, spawnPos, Quaternion.identity);
        SpawnedObjects.Add(spawned);
        var setter = spawned.GetComponent<AIDestinationSetter>();
        setter.target = GoalToGive.transform;
        LastTimeSpawned = Time.time;
    }
}
