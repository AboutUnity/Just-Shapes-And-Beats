using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelSelect = 0;
    private bool levelStart = true;

    public LevelAudioSong levelMusics;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) SceneManager.LoadScene("8 Bit Adventure");

        if (levelStart)
        {
            LevelSetup();
            levelStart = false;
        }
    }

    private void LevelSelect()
    {
        switch (levelSelect)
        {
            case 1:
                this.GetComponent<AudioSource>().clip = levelMusics._8BitAdventure;
                break;
        }
    }

    public void LevelSetup()
    {
        LevelSelect();
        this.GetComponent<AudioSource>().Play();
    }
}
