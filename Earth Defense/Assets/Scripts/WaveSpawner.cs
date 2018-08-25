using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject PrefabToSpawn = null;
    public GameObject GoalToGive = null;
    public float DelayOffset = 0f;
    private float StartTimeOffset = 0f;

    
    public int TotalToSpawn = 100;

    public float TimeBetweenSpawn = 5f;
    private float LastTimeSpawned = 0f;

    private bool first = true;
    private float StartTime = 0f;

    private List<GameObject> SpawnedObjects;
	// Use this for initialization
	void Start () {
        SpawnedObjects = new List<GameObject>();

    }

    void OnEnable()
    {
        //DelayOffset += Time.time;
        //LastTimeSpawned = Time.time;
        StartTimeOffset = Time.time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (first && 0 < Time.time - (DelayOffset + StartTimeOffset))
	    {
	        SpawnEnemyType1();
	        first = false;
	    }
	    if ((LastTimeSpawned + TimeBetweenSpawn < Time.time - (DelayOffset)) && TotalToSpawn > 0)
	    {
	        SpawnEnemyType1();
	    }
	}

    void SpawnEnemyType1()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y += (Random.value * 4f) - 2;
        GameObject spawned = Instantiate(PrefabToSpawn, spawnPos, transform.rotation);
        SpawnedObjects.Add(spawned);
        var setter = spawned.GetComponentInChildren<AIDestinationSetter>();
        setter.target = GoalToGive.transform;
        LastTimeSpawned = Time.time;
        TotalToSpawn--;
        if (TotalToSpawn == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
