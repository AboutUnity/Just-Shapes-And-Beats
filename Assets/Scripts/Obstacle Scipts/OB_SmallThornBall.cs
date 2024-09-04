using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OB_SmallThornBall : MonoBehaviour
{
    public GameObject smallThornBall;
    public GameObject mainThornBall;
    public GameObject flashThornBall;

    public bool isBallMoving = false;
    public float rotatingSpeed = 1;
    public float movingSpeed = 0.03f;

    bool isFlashingCounter = true;
    public int flashingCounter = 0;


    void Start()
    {
        smallThornBall = gameObject;    
    }

    void Update()
    {
        SmallThornBall();
        MainThornBall();
        FlashThornBall();
    }

    public void SmallThornBall()
    {
        if (isBallMoving) smallThornBall.transform.Translate(new Vector3(-movingSpeed, 0, 0));
        if (smallThornBall.transform.position.x < -15) Destroy(smallThornBall);
    }

    public void MainThornBall()
    {
        mainThornBall.transform.Rotate(new Vector3(0, 0, rotatingSpeed));
    }

    public void FlashThornBall()
    {
        if (isFlashingCounter) flashingCounter++;

        flashThornBall.transform.Rotate(new Vector3(0, 0, rotatingSpeed));

        if ((flashingCounter > 0) && ((flashingCounter < 15)))
        {
            flashThornBall.transform.localScale = Vector3.Lerp(flashThornBall.transform.localScale, new Vector3(1.2f, 1.2f, 1), 0.2f);
            flashThornBall.GetComponent<SpriteRenderer>().color = Color.Lerp(flashThornBall.GetComponent<SpriteRenderer>().color, new Color(1, 1, 1, 1), 0.2f);
        }
        if (((flashingCounter > 15)))
        {
            flashThornBall.transform.localScale = Vector3.Lerp(flashThornBall.transform.localScale, new Vector3(0.3f, 0.3f, 1), 0.1f);
            flashThornBall.GetComponent<SpriteRenderer>().color = Color.Lerp(flashThornBall.GetComponent<SpriteRenderer>().color, new Color(1, 1, 1, 0), 0.05f);
        }

        if (flashThornBall.GetComponent<SpriteRenderer>().color == new Color(1, 1, 1, 0))
        {
            isFlashingCounter = false;
            flashingCounter = 0;    
        }
    }
}
