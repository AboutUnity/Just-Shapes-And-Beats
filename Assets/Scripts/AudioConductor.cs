using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioConductor : MonoBehaviour
{
    public float songBpm = 100;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;

    public bool resetdspTime = true;

    void Start()
    {

    }

    void Update()
    {
        if (resetdspTime)
        {
            dspSongTime = (float)AudioSettings.dspTime;
            resetdspTime = false;
        }

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;
        secPerBeat = 60f / songBpm;

        if (this.GetComponent<AudioSource>().clip == this.GetComponent<GameManager>().musics.menuSong) songBpm = 125;
        if (this.GetComponent<AudioSource>().clip == this.GetComponent<GameManager>().musics.tutorialLevel1) songBpm = 140;
        if (this.GetComponent<AudioSource>().clip == this.GetComponent<GameManager>().musics.tutorialLevel2) songBpm = 140;
        if (this.GetComponent<AudioSource>().clip == this.GetComponent<GameManager>().musics.tutorialLevel2) songBpm = 139;
        if (this.GetComponent<AudioSource>().clip == this.GetComponent<GameManager>().musics.tutorialLevel2) songBpm = 138.5f;
    }
}
