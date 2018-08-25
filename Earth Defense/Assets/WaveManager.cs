using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int WaveNumber = 0;
    public List<float> WaveStartTimes;
	
	// Update is called once per frame
	void Update ()
    {
        while (WaveStartTimes.Count < transform.childCount)
        {
            WaveStartTimes.Add(999999);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            if (WaveStartTimes[i] < Time.time)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                WaveNumber++;
            }
        }
	}
}
