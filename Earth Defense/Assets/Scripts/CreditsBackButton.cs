using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsBackButton : MonoBehaviour {

    public GameObject creditsCanvas;
    public GameObject mainMenu;

    // Update is called once per frame
    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        creditsCanvas.SetActive(false);
    }
}
