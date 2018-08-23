using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpinner : MonoBehaviour
{
    public float SpinRate = 1f;
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up, SpinRate * Time.deltaTime);
	}
}
