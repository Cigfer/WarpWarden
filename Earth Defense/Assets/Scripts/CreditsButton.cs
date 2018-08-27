using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour {

    public GameObject creditsCanvas;
    public GameObject mainMenu;


	void Start ()
    {
        creditsCanvas.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsCanvas.SetActive(true);
    }
}
