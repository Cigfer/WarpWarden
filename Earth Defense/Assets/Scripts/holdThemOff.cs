using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdThemOff : MonoBehaviour {

    public GameObject directive;

	void Start ()
    {
        StartCoroutine("Directive");
	}
	
	// Update is called once per frame
	IEnumerator Directive ()
    {
        directive.SetActive(true);

        yield return new WaitForSeconds(3);

        directive.SetActive(false);
	}
}
