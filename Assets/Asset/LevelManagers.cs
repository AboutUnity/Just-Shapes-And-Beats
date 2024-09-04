using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagers : MonoBehaviour
{
    public int levelSelect = 0;
    private bool levelStart = true;

    public LevelAudioSong levelMusics;

    private void Update()
    {
        if (levelStart)
        {
            LevelSetUp();
            levelStart = false;
        }
    }

    private void LevelSetUp()
    {
        LevelSelect();
        this.GetComponent<AudioSource>().Play();
    }

    private void LevelSelect()
    {
        switch (levelSelect)
        {
            case 1:
                this.GetComponent <AudioSource>().clip = levelMusics._8BitAdventure; break;
        }
    }
}
