using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public TImer timer;

    public Animator animator;

    private int levelToLoad;

    public GameObject fader;

    public Button playButton;
    //public Button backToMainMenu;

    void Start()
    {
        //timer = GetComponent<TImer>;

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Title")
        {
            fader.SetActive(false);
        }
        else
        {
            fader.SetActive(true);
        }

        if (sceneName == "WinScreen")
        {
            Cursor.visible = true;
        }
       
        Button playB = playButton.GetComponent<Button>();
        //Button backToM = backToMainMenu.GetComponent<Button>();

        playB.onClick.AddListener(delegate { FadeToLevel(1); }) ;
        //backToM.onClick.AddListener(delegate { FadeToLevel(0); });
    }

	void Update ()
    {
        if (timer.m_leftTime <= 0)
        {
            FadeToLevel(2);
        }
    }

    public void FadeToLevel (int levelIndex)
    {
        fader.SetActive(true);
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
