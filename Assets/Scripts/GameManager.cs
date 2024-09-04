using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject thisGameManager;
    public GameObject levelGoal;
    public GameObject shapePlayer;
    public GameObject goal;
    public TriangleGoal triangleGoalClass;
    public GameObject introTitle;
    public GameObject backGround;
    public GameObject levelTitle;
    public GameObject comingSoonTitle;

    public Obstacle obstacles;
    public AudioSound musics;

    public int gameLevel = 0;

    public bool isLevelStart = true;
    private bool isPlayAudio = true;
    public bool doGoalTimer = false;
    public bool gameLevelMenu = false;
    public bool gameLevel0 = false;
    public bool gameLevel1 = false;
    public bool gameLevel2 = false;
    public bool gameLevel3 = false;
    public bool gameLevel4 = false;
    public bool gameLevel5 = false;
    public bool gameLevel6 = false;

    public float goalTimer = 0;


    void Start()
    {
        Application.targetFrameRate = 100;
        thisGameManager = gameObject;
        isLevelStart = true;
        isPlayAudio = true;
        doGoalTimer = false;

        gameLevel = -1;
    }

    void Update()
    {
        LevelLoad();

        if (isPlayAudio)
        {
            this.GetComponent<AudioSource>().Play();
            isPlayAudio = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(0);
        }

        if (doGoalTimer) GoalCall();
        GameLevelSetUp();

        if (gameLevelMenu || gameLevel6)
        {
            shapePlayer.SetActive(false);
        }
        else shapePlayer.SetActive(true);
        if (gameLevel0)
        {
            levelTitle.SetActive(true);
        }
        else levelTitle.SetActive(false);
        if (gameLevel6)
        {
            comingSoonTitle.SetActive(true);
        }
        else comingSoonTitle.SetActive(false);

        if (Input.GetKeyDown("escape")) Application.Quit();
    }

    private void LevelLoad()
    {
        if (isLevelStart)
        {
            switch (gameLevel)
            {
                case -1:
                    this.GetComponent<AudioSource>().clip = musics.menuSong;
                    LevelRestart();
                    gameLevelMenu = true;
                    break;
                case 0:
                    LevelRestart();
                    this.GetComponent<AudioSource>().Stop();
                    gameLevel0 = true;
                    break;
                case 1:
                    this.GetComponent<AudioSource>().clip = musics.tutorialLevel1;
                    LevelRestart();
                    gameLevel1 = true;
                    break;
                case 2:
                    this.GetComponent<AudioSource>().clip = musics.tutorialLevel2;
                    LevelRestart();
                    gameLevel2 = true;
                    break;
                case 3:
                    this.GetComponent<AudioSource>().clip = musics.tutorialLevel3;
                    LevelRestart();
                    gameLevel3 = true;
                    break;
                case 4:
                    this.GetComponent<AudioSource>().clip = musics.tutorialLevel4;
                    LevelRestart();
                    gameLevel4 = true;
                    break;
                case 5:
                    this.GetComponent<AudioSource>().clip = musics.tutorialLevel5;
                    LevelRestart();
                    gameLevel5 = true;
                    break;
                case 6:
                    this.GetComponent<AudioSource>().clip = musics.tutorialLastLevel;
                    LevelRestart();
                    gameLevel6 = true;
                    break;
            }
        }
    }

    private void LevelRestart()
    {
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<LevelActive>().smallBlashBallList.Clear();
        this.GetComponent<LevelActive>().smallThornBallList.Clear();
        this.GetComponent<LevelActive>().thinBlashStickList.Clear();
        isLevelStart = false;
        shapePlayer.GetComponent<ShapeController>().canMove = true;
        doGoalTimer = true;
        goalTimer = 0;
        DestroyAllObject("Obstacle");
        shapePlayer.transform.position = new Vector3(-6, 0, 0);

        this.GetComponent<AudioConductor>().songPosition = 0;
        this.GetComponent<AudioConductor>().resetdspTime = true;
        gameLevelMenu = false;
        gameLevel0 = false;
        gameLevel1 = false;
        gameLevel2 = false;
        gameLevel3 = false;
        gameLevel4 = false;
        gameLevel5 = false;
        gameLevel6 = false;
    }

    public void GameLevelSetUp()
    {
        if (gameLevelMenu)
        {
            this.GetComponent<LevelActive>().LevelActiveMenu();
            this.introTitle.SetActive(true);

            backGround.GetComponent<RawImage>().color = new Color(0, 0.096f, 0.13f, 1);
        }
        else this.introTitle.SetActive(false);
        if (gameLevel0)
        {
            this.GetComponent<LevelActive>().LevelActiveNo0();
            backGround.GetComponent<RawImage>().color = new Color(0, 0, 0, 1);
        }
        if (gameLevel1)
        {
            this.GetComponent<LevelActive>().LevelActiveNo1();
            backGround.GetComponent<RawImage>().color = new Color(0, 0.096f, 0.13f, 1);
        }
        if (gameLevel2)
        {
            this.GetComponent<LevelActive>().LevelActiveNo2();
            backGround.GetComponent<RawImage>().color = new Color(0.235f, 0.153f, 0.243f, 1);
        }
        if (gameLevel3)
        {
            this.GetComponent<LevelActive>().LevelActiveNo3();
            backGround.GetComponent<RawImage>().color = new Color(0, 0.141f, 0.196f, 1);
        }
        if (gameLevel4)
        {
            this.GetComponent<LevelActive>().LevelActiveNo4();
            backGround.GetComponent<RawImage>().color = new Color(0.266f, 0.266f, 0.266f, 1);
        }
        if (gameLevel5)
        {
            this.GetComponent<LevelActive>().LevelActiveNo5();
            backGround.GetComponent<RawImage>().color = new Color(0, 0.096f, 0.13f, 1);
        }
        if (gameLevel6)
        {
            this.GetComponent<LevelActive>().LevelActiveNo6();
            backGround.GetComponent<RawImage>().color = new Color(0, 0.141f, 0.196f, 1);
        }
    }

    public void GoalCall()
    {
        goalTimer += Time.deltaTime;

        if (!gameLevel0 && !gameLevelMenu && !gameLevel6 && goalTimer > 8)
        {
            goal.transform.position = Vector3.Lerp(goal.transform.position, new Vector3(7, 0, goal.transform.position.z), 0.05f);
            goal.GetComponent<CircleCollider2D>().enabled = true;
            triangleGoalClass.GetComponent<Animator>().SetTrigger("ShapeReturnNormal");
        }

        if (gameLevel0 && goalTimer > 1)
        {
            goal.transform.position = Vector3.Lerp(goal.transform.position, new Vector3(7, 0, goal.transform.position.z), 0.05f);
            goal.GetComponent<CircleCollider2D>().enabled = true;
            triangleGoalClass.GetComponent<Animator>().SetTrigger("ShapeReturnNormal");
        }


        if (gameLevelMenu && goalTimer > 8)
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                gameLevel = 0;
                isLevelStart = true;
            }
        }
    }

    public void DestroyAllObject(string tag)
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }
}
