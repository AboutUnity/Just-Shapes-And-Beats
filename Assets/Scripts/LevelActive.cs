using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelActive : MonoBehaviour
{
    private GameManager gameManager;

    public float beatTimer = 0;
    [HideInInspector] public List<GameObject> smallBlashBallList = new List<GameObject>();
    [HideInInspector] public List<GameObject> smallThornBallList = new List<GameObject>();
    [HideInInspector] public List<GameObject> thinBlashStickList = new List<GameObject>();
    [HideInInspector] public List<GameObject> fullBlashSquareList = new List<GameObject>();
    [HideInInspector] public List<GameObject> fullBlashCircleList = new List<GameObject>();

    public bool doResetTimer = false;
    private bool smallBlashBallMove = false;

    public float thinBlashStickDelay;
    public float fullBlashSquareDelay;
    public float fullBlashCircleDelay;

    private int obstacleCounter = 1;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        obstacleCounter = 0;
    }

    void Update()
    {
        beatTimer = (float)System.Math.Round(this.GetComponent<AudioConductor>().songPositionInBeats, 2);
    }

    private void AudioReset()
    {
        this.GetComponent<AudioConductor>().songPosition = 0;
        this.GetComponent<AudioConductor>().resetdspTime = true;
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().Play();

        smallBlashBallList.Clear();
        smallThornBallList.Clear();
        thinBlashStickList.Clear();
        fullBlashSquareList.Clear();
        fullBlashCircleList.Clear();
    }

    public void LevelActiveMenu()
    {
        if (beatTimer > gameManager.musics.menuSong.length)
        {
            beatTimer = 0;
        }
    }

    public void LevelActiveNo0()
    {
        if (this.GetComponent<GameManager>().gameLevelMenu) gameManager.introTitle.SetActive(true);
        else if (!this.GetComponent<GameManager>().gameLevelMenu) gameManager.introTitle.SetActive(false);
    }

    public void LevelActiveNo1()
    {
        if ((Mathf.FloorToInt(beatTimer) >= 0) && (System.Math.Round(beatTimer, 1) < 1.5f)  && smallBlashBallList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 1.5f) && (Mathf.FloorToInt(beatTimer) < 3) && smallBlashBallList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 3) && (Mathf.FloorToInt(beatTimer) < 4) && smallBlashBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 0, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 4) && (System.Math.Round(beatTimer, 1) < 5.5f) && smallBlashBallList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 5.5f) && (Mathf.FloorToInt(beatTimer) < 8) && smallBlashBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }

        if ((Mathf.FloorToInt(beatTimer) >= 8) && (System.Math.Round(beatTimer, 1) < 9.5f) && smallBlashBallList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 9.5f) && (Mathf.FloorToInt(beatTimer) < 11) && smallBlashBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 11) && (Mathf.FloorToInt(beatTimer) < 12) && smallBlashBallList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 0, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 12) && (System.Math.Round(beatTimer, 1) < 13.5f) && smallBlashBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 13.5f) && (Mathf.FloorToInt(beatTimer) < 14) && smallBlashBallList.Count == 9)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 14) && (System.Math.Round(beatTimer, 2) < 14.75f) && smallBlashBallList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 3, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 14.75f) && (System.Math.Round(beatTimer, 1) < 15.5f) && smallBlashBallList.Count == 11)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -4, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 15.5f) && (Mathf.FloorToInt(beatTimer) < 16) && smallBlashBallList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 3, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
        }

        if (this.GetComponent<AudioConductor>().songPosition >= (float)gameManager.musics.tutorialLevel1.length)
        {
            AudioReset();
        }
    }

    public void LevelActiveNo2()
    {
        if (smallBlashBallMove)
        {
            GameObject blashBall = null;
            obstacleCounter = smallBlashBallList.Count - 1;
            if (smallBlashBallList.Count >= 1)
            {
                blashBall = smallBlashBallList[obstacleCounter];
            }
            if (obstacleCounter % 2 == 1)
            {
                blashBall.transform.position = Vector3.Lerp(blashBall.transform.position, new Vector3(4, -3, 0), 0.05f);
                if (blashBall.transform.position.y >= -3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
            if (obstacleCounter % 2 == 0)
            {
                blashBall.transform.position = Vector3.Lerp(blashBall.transform.position, new Vector3(4, 3, 0), 0.05f);
                if (blashBall.transform.position.y <= 3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
        }

        if (smallBlashBallList.Count == 0)
        {
            GameObject nullObject = GameObject.FindGameObjectWithTag("Null");
            smallBlashBallList.Add(nullObject);
        }

        if ((Mathf.FloorToInt(beatTimer) >= 1) && (Mathf.FloorToInt(beatTimer) < 3) && smallBlashBallList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 3) && (Mathf.FloorToInt(beatTimer) < 5) && smallBlashBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;

        }
        if ((Mathf.FloorToInt(beatTimer) >= 5) && (Mathf.FloorToInt(beatTimer) < 7) && smallBlashBallList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 7) && (Mathf.FloorToInt(beatTimer) < 9) && smallBlashBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 9) && (Mathf.FloorToInt(beatTimer) < 11) && smallBlashBallList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 11) && (Mathf.FloorToInt(beatTimer) < 13) && smallBlashBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 13) && (Mathf.FloorToInt(beatTimer) < 15) && smallBlashBallList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 15) && (Mathf.FloorToInt(beatTimer) < 17) && smallBlashBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }

        if ((Mathf.FloorToInt(beatTimer) >= 0) && (System.Math.Round(beatTimer, 1) < 1.5f) && smallThornBallList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 1.5f) && (Mathf.FloorToInt(beatTimer) < 3) && smallThornBallList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 3) && (Mathf.FloorToInt(beatTimer) < 4) && smallThornBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 0, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 4) && (System.Math.Round(beatTimer, 1) < 5.5f) && smallThornBallList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 5.5f) && (Mathf.FloorToInt(beatTimer) < 8) && smallThornBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 8) && (System.Math.Round(beatTimer, 1) < 9.5f) && smallThornBallList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 9.5f) && (Mathf.FloorToInt(beatTimer) < 11) && smallThornBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 11) && (Mathf.FloorToInt(beatTimer) < 12) && smallThornBallList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 0, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 12) && (System.Math.Round(beatTimer, 1) < 13.5f) && smallThornBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 13.5f) && (Mathf.FloorToInt(beatTimer) < 14) && smallThornBallList.Count == 9)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((Mathf.FloorToInt(beatTimer) >= 14) && (System.Math.Round(beatTimer, 2) < 14.75f) && smallThornBallList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 3, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 14.75f) && (System.Math.Round(beatTimer, 1) < 15.5f) && smallThornBallList.Count == 11)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -4, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 15.5f) && (Mathf.FloorToInt(beatTimer) < 16) && smallThornBallList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 3, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }

        if (this.GetComponent<AudioConductor>().songPosition >= (float)gameManager.musics.tutorialLevel2.length)
        {
            AudioReset();
        }
    }

    public void LevelActiveNo3()
    {
        if (smallBlashBallMove)
        {
            GameObject blashBall = null;
            obstacleCounter = smallBlashBallList.Count - 1;
            if (smallBlashBallList.Count >= 1)
            {
                blashBall = smallBlashBallList[obstacleCounter];
            }
            if (obstacleCounter % 2 == 1)
            {
                blashBall.transform.position = Vector3.Lerp(blashBall.transform.position, new Vector3(4, -3, 0), 0.05f);
                if (blashBall.transform.position.y >= -3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
            if (obstacleCounter % 2 == 0)
            {
                blashBall.transform.position = Vector3.Lerp(blashBall.transform.position, new Vector3(4, 3, 0), 0.05f);
                if (blashBall.transform.position.y <= 3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
        }

        if (smallBlashBallList.Count == 0)
        {
            GameObject nullObject = GameObject.FindGameObjectWithTag("Null");
            smallBlashBallList.Add(nullObject);
        }

        if ((Mathf.FloorToInt(beatTimer) >= 1) && (Mathf.FloorToInt(beatTimer) < 3) && smallBlashBallList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 3) && (Mathf.FloorToInt(beatTimer) < 5) && smallBlashBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;

        }
        if ((Mathf.FloorToInt(beatTimer) >= 5) && (Mathf.FloorToInt(beatTimer) < 7) && smallBlashBallList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 7) && (Mathf.FloorToInt(beatTimer) < 9) && smallBlashBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 9) && (Mathf.FloorToInt(beatTimer) < 11) && smallBlashBallList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 11) && (Mathf.FloorToInt(beatTimer) < 13) && smallBlashBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 13) && (Mathf.FloorToInt(beatTimer) < 15) && smallBlashBallList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 15) && (Mathf.FloorToInt(beatTimer) < 17) && smallBlashBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            smallBlashBallMove = true;
        }

        thinBlashStickDelay = 0.3f;
        if ((System.Math.Round(beatTimer, 1) >= 0.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 2 - thinBlashStickDelay) && thinBlashStickList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 2 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 4.5f - thinBlashStickDelay) && thinBlashStickList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 4.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 6 - thinBlashStickDelay) && thinBlashStickList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-1.5f, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 6 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 6.5f - thinBlashStickDelay) && thinBlashStickList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(0, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 6.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 8.5f - thinBlashStickDelay) && thinBlashStickList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(1, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 10 - thinBlashStickDelay) && thinBlashStickList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(2.5f, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 10 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 12.5f - thinBlashStickDelay) && thinBlashStickList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3.5f, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 12.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 14 - thinBlashStickDelay) && thinBlashStickList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(5, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 14 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 2) < 14.75f - thinBlashStickDelay) && thinBlashStickList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(6.5f, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 14.75f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 16 - thinBlashStickDelay) && thinBlashStickList.Count == 9)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(7.5f, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
        }

        if ((System.Math.Round(beatTimer, 2) >= 0) && (System.Math.Round(beatTimer, 2) < 0.75f) && smallThornBallList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 3, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 0.75) && (System.Math.Round(beatTimer, 2) < 2.25f) && smallThornBallList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 2.25f) && (System.Math.Round(beatTimer, 2) < 3.75f) && smallThornBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 3.75f) && (System.Math.Round(beatTimer, 2) < 4.75f) && smallThornBallList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 0, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 4.75f) && (System.Math.Round(beatTimer, 2) < 6.25f) && smallThornBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 6.25f) && (System.Math.Round(beatTimer, 2) < 8.75f) && smallThornBallList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 8.75f) && (System.Math.Round(beatTimer, 2) < 10.25f) && smallThornBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 10.25f) && (System.Math.Round(beatTimer, 2) < 11.75f) && smallThornBallList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 11.75f) && (System.Math.Round(beatTimer, 2) < 12.75f) && smallThornBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 0, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 12.75f) && (System.Math.Round(beatTimer, 2) < 14.25f) && smallThornBallList.Count == 9)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 14.25f ) && (System.Math.Round(beatTimer, 2) < 14.75f) && smallThornBallList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -2, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 14.75f) && (System.Math.Round(beatTimer, 2) < 15.5f) && smallThornBallList.Count == 11)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, 3, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 15.5f) && (System.Math.Round(beatTimer, 2) < 16) && smallThornBallList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallThornBall, new Vector3(9, -4, 0), Quaternion.identity);
            smallThornBallList.Add(thisObstacle);
        }

        if (this.GetComponent<AudioConductor>().songPosition >= (float)gameManager.musics.tutorialLevel3.length)
        {
            AudioReset();
        }
    }

    public void LevelActiveNo4()
    {
        if (smallBlashBallMove)
        {
            GameObject blashBall1 = null;
            GameObject blashBall2 = null;
            obstacleCounter = smallBlashBallList.Count - 2;
            if (smallBlashBallList.Count >= 3)
            {
                blashBall1 = smallBlashBallList[obstacleCounter];
                blashBall2 = smallBlashBallList[obstacleCounter + 1];
            }
            if (obstacleCounter % 4 == 2 && obstacleCounter > 0)
            {
                blashBall1.transform.position = Vector3.Lerp(blashBall1.transform.position, new Vector3(3, -3, 0), 0.05f);
                blashBall2.transform.position = Vector3.Lerp(blashBall2.transform.position, new Vector3(-3, 3, 0), 0.05f);
                if (blashBall1.transform.position.y >= -3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
            if (obstacleCounter % 4 == 0 && obstacleCounter > 0)
            {
                blashBall1.transform.position = Vector3.Lerp(blashBall1.transform.position, new Vector3(4, 3, 0), 0.05f);
                blashBall2.transform.position = Vector3.Lerp(blashBall2.transform.position, new Vector3(-4, -3, 0), 0.05f);
                if (blashBall1.transform.position.y <= 3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
        }

        if (smallBlashBallList.Count <= 1)
        {
            GameObject nullObject = GameObject.FindGameObjectWithTag("Null");
            smallBlashBallList.Add(nullObject);
            smallBlashBallList.Add(nullObject);
        }

        if ((Mathf.FloorToInt(beatTimer) >= 2) && (Mathf.FloorToInt(beatTimer) < 4) && smallBlashBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 4) && (Mathf.FloorToInt(beatTimer) < 6) && smallBlashBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;

        }
        if ((Mathf.FloorToInt(beatTimer) >= 6) && (Mathf.FloorToInt(beatTimer) < 8) && smallBlashBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 8) && (Mathf.FloorToInt(beatTimer) < 10) && smallBlashBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 10) && (Mathf.FloorToInt(beatTimer) < 12) && smallBlashBallList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 12) && (Mathf.FloorToInt(beatTimer) < 14) && smallBlashBallList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 14) && (Mathf.FloorToInt(beatTimer) < 16) && smallBlashBallList.Count == 14)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 16) && (Mathf.FloorToInt(beatTimer) < 18) && smallBlashBallList.Count == 16)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 3, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -3, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }

        thinBlashStickDelay = -1;
        if ((System.Math.Round(beatTimer, 1) >= 1 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 2.5f - thinBlashStickDelay) && thinBlashStickList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 2.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 5 - thinBlashStickDelay) && thinBlashStickList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 5 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 6.5f - thinBlashStickDelay) && thinBlashStickList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 6.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 9 - thinBlashStickDelay) && thinBlashStickList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 9 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 10.5f - thinBlashStickDelay) && thinBlashStickList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 10.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 13 - thinBlashStickDelay) && thinBlashStickList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 13 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 14.5f - thinBlashStickDelay) && thinBlashStickList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 14.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 16 - thinBlashStickDelay) && thinBlashStickList.Count == 14)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }

        fullBlashSquareDelay = 4;
        if ((System.Math.Round(beatTimer, 1) >= 8 - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 8.25f - fullBlashSquareDelay) && fullBlashSquareList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-8, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-8, 4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle2);
            var thisObstacle3 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-8, -4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle3);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.25f - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 8.5f - fullBlashSquareDelay) && fullBlashSquareList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-4, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-4, 4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle2);
            var thisObstacle3 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-4, -4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle3);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.5f - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 8.75f - fullBlashSquareDelay) && fullBlashSquareList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(0, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(0, 4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle2);
            var thisObstacle3 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(0, -4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle3);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.75f - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 9f - fullBlashSquareDelay) && fullBlashSquareList.Count == 9)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(4, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(4, 4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle2);
            var thisObstacle3 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(4, -4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle3);
        }
        if ((System.Math.Round(beatTimer, 1) >= 9 - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 9.25f - fullBlashSquareDelay) && fullBlashSquareList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(8, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(8, 4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle2);
            var thisObstacle3 = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(8, -4, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle3);
        }

        if (this.GetComponent<AudioConductor>().songPosition >= (float)gameManager.musics.tutorialLevel4.length)
        {
            AudioReset();
        }
    }

    public void LevelActiveNo5()
    {
        if (smallBlashBallMove)
        {
            GameObject blashBall1 = null;
            GameObject blashBall2 = null;
            obstacleCounter = smallBlashBallList.Count - 2;
            if (smallBlashBallList.Count >= 3)
            {
                blashBall1 = smallBlashBallList[obstacleCounter];
                blashBall2 = smallBlashBallList[obstacleCounter + 1];
            }
            if (obstacleCounter % 4 == 2 && obstacleCounter > 0)
            {
                blashBall1.transform.position = Vector3.Lerp(blashBall1.transform.position, new Vector3(3, -3, 0), 0.05f);
                blashBall2.transform.position = Vector3.Lerp(blashBall2.transform.position, new Vector3(-3, 3, 0), 0.05f);
                if (blashBall1.transform.position.y >= -3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
            if (obstacleCounter % 4 == 0 && obstacleCounter > 0)
            {
                blashBall1.transform.position = Vector3.Lerp(blashBall1.transform.position, new Vector3(4, 3, 0), 0.05f);
                blashBall2.transform.position = Vector3.Lerp(blashBall2.transform.position, new Vector3(-4, -3, 0), 0.05f);
                if (blashBall1.transform.position.y <= 3.2f)
                {
                    smallBlashBallMove = false;
                }
            }
        }

        if (smallBlashBallList.Count <= 1)
        {
            GameObject nullObject = GameObject.FindGameObjectWithTag("Null");
            smallBlashBallList.Add(nullObject);
            smallBlashBallList.Add(nullObject);
        }

        if ((Mathf.FloorToInt(beatTimer) >= 2) && (Mathf.FloorToInt(beatTimer) < 4) && smallBlashBallList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 4) && (Mathf.FloorToInt(beatTimer) < 6) && smallBlashBallList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;

        }
        if ((Mathf.FloorToInt(beatTimer) >= 6) && (Mathf.FloorToInt(beatTimer) < 8) && smallBlashBallList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 8) && (Mathf.FloorToInt(beatTimer) < 10) && smallBlashBallList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 10) && (Mathf.FloorToInt(beatTimer) < 12) && smallBlashBallList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 12) && (Mathf.FloorToInt(beatTimer) < 14) && smallBlashBallList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 14) && (Mathf.FloorToInt(beatTimer) < 16) && smallBlashBallList.Count == 14)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(3, -6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-3, 6, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }
        if ((Mathf.FloorToInt(beatTimer) >= 16) && (Mathf.FloorToInt(beatTimer) < 18) && smallBlashBallList.Count == 16)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(4, 3, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.smallBlashBall, new Vector3(-4, -3, 0), Quaternion.identity);
            smallBlashBallList.Add(thisObstacle2);
            smallBlashBallMove = true;
        }

        thinBlashStickDelay = -2.5f;
        if ((System.Math.Round(beatTimer, 1) >= 1 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 2.5f - thinBlashStickDelay) && thinBlashStickList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 2.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 5 - thinBlashStickDelay) && thinBlashStickList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 5 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 6.5f - thinBlashStickDelay) && thinBlashStickList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 6.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 9 - thinBlashStickDelay) && thinBlashStickList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 9 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 10.5f - thinBlashStickDelay) && thinBlashStickList.Count == 8)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 10.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 13 - thinBlashStickDelay) && thinBlashStickList.Count == 10)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 13 - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 14.5f - thinBlashStickDelay) && thinBlashStickList.Count == 12)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(4, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }
        if ((System.Math.Round(beatTimer, 1) >= 14.5f - thinBlashStickDelay) && (System.Math.Round(beatTimer, 1) < 16 - thinBlashStickDelay) && thinBlashStickList.Count == 14)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(-3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle);
            var thisObstacle2 = Instantiate(gameManager.obstacles.thinBlashStick, new Vector3(3, 0, 0), Quaternion.identity);
            thinBlashStickList.Add(thisObstacle2);
        }

        fullBlashSquareDelay = 3;
        if ((System.Math.Round(beatTimer, 1) >= 8 - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 8.25f - fullBlashSquareDelay) && fullBlashSquareList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-8, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.25f - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 8.5f - fullBlashSquareDelay) && fullBlashSquareList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(-4, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.5f - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 8.75f - fullBlashSquareDelay) && fullBlashSquareList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(0, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 8.75f - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 9f - fullBlashSquareDelay) && fullBlashSquareList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(4, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 1) >= 9 - fullBlashSquareDelay) && (System.Math.Round(beatTimer, 1) < 9.25f - fullBlashSquareDelay) && fullBlashSquareList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashSquare, new Vector3(8, 0, 0), Quaternion.identity);
            fullBlashSquareList.Add(thisObstacle);
        }

        fullBlashCircleDelay = 3;
        if ((System.Math.Round(beatTimer, 2) >= 4 - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 4.25f - fullBlashCircleDelay) && fullBlashCircleList.Count == 0)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(-3, 2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 4.25f - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 4.5f - fullBlashCircleDelay) && fullBlashCircleList.Count == 1)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(3, 2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 4.5f - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 4.75f - fullBlashCircleDelay) && fullBlashCircleList.Count == 2)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(-3, -2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 4.75f - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 5 - fullBlashCircleDelay) && fullBlashCircleList.Count == 3)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(3, -2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 12 - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 12.25f - fullBlashCircleDelay) && fullBlashCircleList.Count == 4)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(-3, 2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 12.25f - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 12.5f - fullBlashCircleDelay) && fullBlashCircleList.Count == 5)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(3, 2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 12.5f - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 12.75f - fullBlashCircleDelay) && fullBlashCircleList.Count == 6)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(-3, -2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }
        if ((System.Math.Round(beatTimer, 2) >= 12.75f - fullBlashCircleDelay) && (System.Math.Round(beatTimer, 2) < 13 - fullBlashCircleDelay) && fullBlashCircleList.Count == 7)
        {
            var thisObstacle = Instantiate(gameManager.obstacles.fullBlashCircle, new Vector3(3, -2.5f, 0), Quaternion.identity);
            fullBlashCircleList.Add(thisObstacle);
        }




        if (this.GetComponent<AudioConductor>().songPosition >= (float)gameManager.musics.tutorialLevel5.length)
        {
            AudioReset();
        }
    }

    public void LevelActiveNo6()
    {

    }
}
