using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class livesScript : MonoBehaviour {

    public Text powerSiphoned;

    public int damage = 100;

    void Start()
    {
        powerSiphoned = GetComponent<Text>();
    }

    void Update()
    {
        powerSiphoned.text = "Power Remaining: " + damage + "%";
    }
}
