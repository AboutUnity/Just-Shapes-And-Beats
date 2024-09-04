using UnityEngine;

[System.Serializable]
public struct Obstacle
{
    public GameObject smallThornBall;
    public GameObject smallBlashBall;
    public GameObject thinBlashStick;
    public GameObject fullBlashSquare;
    public GameObject fullBlashCircle;
}

[System.Serializable]
public struct AudioSound
{
    public AudioClip catchingGoalSound;

    public AudioClip menuSong;

    public AudioClip tutorialLevel1;
    public AudioClip tutorialLevel2;
    public AudioClip tutorialLevel3;
    public AudioClip tutorialLevel4;
    public AudioClip tutorialLevel5;
    public AudioClip tutorialLastLevel;
}

[System.Serializable]
public struct LevelAudioSong
{
    public AudioClip _8BitAdventure;
}
