using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject shapePlayer;
    public GameObject shapeMovingParticle;
    public GameObject dashingRing;
    public TriangleGoal triangleGoalClass;

    public Sprite fullHealth;
    public Sprite shape2Health;
    public Sprite shape1Health;

    public bool canMove = true;
    private bool isMovingButtonRelease = false;
    private bool isMovingToStandCounter = false;
    private bool isStartDashing = false;
    private bool isDashingCounter = true;
    private bool isHitObstacle = false;
    private bool isHitIntoTarget = false;
    private bool hitOnce = false;
    private bool isCatchGoal = false;
    private bool isLifeBubble = false;

    public int shapeHealth = 3;
    private int movingToStandCounter = 0;
    private int dashingResetCounter = 0;
    private int hittingCounter = 0;

    private float lifeBubbleCounter = 0;
    private float movingSpeed = 0.03f;
    private float dashingSpeed = 0.05f;
    private float dashingLength = 4;
    private float rotationSpeed = 0.05f;

    private Vector2 hitTargetPosition;

    private Vector3 shapeDashingTargetPosition;
    private Vector3 shapeOriginalScale;
    private Vector3 shapeOriginalPosition;

    public Vector4 screenBorder;

    //===================================================================================================================================================================================================

    void Start()
    {
        shapePlayer = gameObject;
        shapeOriginalScale = shapePlayer.transform.localScale;
        shapeOriginalPosition = shapePlayer.transform.position;
        shapeMovingParticle.SetActive(false);

        rotationSpeed = 0.4f;
        dashingLength = 4;
        dashingSpeed = 0.05f;
        movingSpeed = 0.03f;
        dashingResetCounter = 0;
    }

    void Update()
    {
        ShapeMovingSolution();

        if (shapePlayer.transform.position.x < screenBorder.x) shapePlayer.transform.position = new Vector3(screenBorder.x, shapePlayer.transform.position.y, shapePlayer.transform.position.z);
        if (shapePlayer.transform.position.y < screenBorder.y) shapePlayer.transform.position = new Vector3(shapePlayer.transform.position.x, screenBorder.y, shapePlayer.transform.position.z);
        if (shapePlayer.transform.position.x > screenBorder.z) shapePlayer.transform.position = new Vector3(screenBorder.z, shapePlayer.transform.position.y, shapePlayer.transform.position.z);
        if (shapePlayer.transform.position.y > screenBorder.w) shapePlayer.transform.position = new Vector3(shapePlayer.transform.position.x, screenBorder.w, shapePlayer.transform.position.z);

        HitObstacle();
        CatchTriangleGoal();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle") && (!hitOnce))
        {
            hitOnce = true;
            isHitObstacle = true;
        }
        if (collision.gameObject.tag.Equals("Level Goal"))
        {
            canMove = false;
            isCatchGoal = true;
            gameManager.doGoalTimer = false;
            shapePlayer.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle") && (!hitOnce))
        { 

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle") && (hitOnce))
        {
            hitOnce = false;
            isHitObstacle = false;
        }
    }

    //===================================================================================================================================================================================================

    public void ShapeMovingSolution()
    {
        ShapeMoveToStand();

        //Moving Left
        if (canMove && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) ShapeMovingControl(90, 180, Vector2.left);
        //Moving Right
        else if (canMove && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) ShapeMovingControl(-90, 0, Vector2.right);
        //Moving Up
        if (canMove && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)) ShapeMovingControl(0, 90, Vector2.up);
        //Moving Down
        else if (canMove && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A)) ShapeMovingControl(-180, -90, Vector2.down);
        //Moving Left Up
        if (canMove && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) ShapeMovingControl(45, 135, new Vector2(-1, 1));
        //Moving Left Down
        if (canMove && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) ShapeMovingControl(135, -135, new Vector2(-1, -1));
        //Moving Right Up
        if (canMove && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) ShapeMovingControl(-45, 45, new Vector2(1, 1));
        //Moving Right Down
        if (canMove && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) ShapeMovingControl(-135, -45, new Vector2(1, -1));

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        //|| (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            isMovingButtonRelease = true;
            isMovingToStandCounter = true;
        }
    }

    private void ShapeMovingControl(int degree, int particleDegree, Vector2 movingDirection)
    {
        //Reset Standing Movement
        movingToStandCounter = 0;
        isMovingButtonRelease = false;

        //Moving Movement
        shapePlayer.transform.rotation = Quaternion.Lerp(shapePlayer.transform.rotation, Quaternion.Euler(0, 0, degree), rotationSpeed);
        shapePlayer.transform.localScale = Vector3.Lerp(shapePlayer.transform.localScale, new Vector3(shapeOriginalScale.x * 0.8f, shapeOriginalScale.y * 1.3f, shapeOriginalScale.z), rotationSpeed / 2);
        shapePlayer.transform.position += new Vector3(movingSpeed * movingDirection.x, movingSpeed * movingDirection.y, 0);

        //Particle Solvement
        //shapeMovingParticle.transform.position = shapePlayer.transform.position;
        //shapeMovingParticle.transform.rotation = Quaternion.Lerp(shapeMovingParticle.transform.rotation, Quaternion.Euler(particleDegree, -90, 90), rotationSpeed);
        //shapeMovingParticle.SetActive(true);

        //Dashing Solvement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shapeDashingTargetPosition = new Vector3(shapePlayer.transform.position.x + dashingLength * movingDirection.x, shapePlayer.transform.position.y + dashingLength * movingDirection.y, 0);
            shapePlayer.GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(this.dashingRing, shapePlayer.transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shapePlayer.transform.position = Vector3.Lerp(shapePlayer.transform.position, new Vector3(shapeDashingTargetPosition.x, shapeDashingTargetPosition.y, 0), dashingSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) shapePlayer.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void ShapeMoveToStand()
    {
        if (isMovingButtonRelease)
        {
            shapePlayer.transform.rotation = Quaternion.Lerp(shapePlayer.transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed);

            if (isMovingToStandCounter) movingToStandCounter++;

            if ((movingToStandCounter > 00) && (movingToStandCounter <= 13)) shapePlayer.transform.localScale = Vector3.Lerp(shapePlayer.transform.localScale, new Vector3(shapeOriginalScale.x, shapeOriginalScale.y, shapeOriginalScale.z), rotationSpeed / 2);
            if ((movingToStandCounter > 13) && (movingToStandCounter <= 30)) shapePlayer.transform.localScale = Vector3.Lerp(shapePlayer.transform.localScale, new Vector3(shapeOriginalScale.x * 0.7f, shapeOriginalScale.y * 1.5f, shapeOriginalScale.z), rotationSpeed / 2);
            if ((movingToStandCounter > 30) && (movingToStandCounter <= 46)) shapePlayer.transform.localScale = Vector3.Lerp(shapePlayer.transform.localScale, new Vector3(shapeOriginalScale.x * 1.3f, shapeOriginalScale.y * 0.8f, shapeOriginalScale.z), rotationSpeed / 2);
            if ((movingToStandCounter > 46) && (movingToStandCounter <= 56)) shapePlayer.transform.localScale = Vector3.Lerp(shapePlayer.transform.localScale, new Vector3(shapeOriginalScale.x * 0.9f , shapeOriginalScale.y * 1.1f, shapeOriginalScale.z), rotationSpeed / 2);
            if ((movingToStandCounter > 56) && (movingToStandCounter <= 70)) shapePlayer.transform.localScale = Vector3.Lerp(shapePlayer.transform.localScale, new Vector3(shapeOriginalScale.x, shapeOriginalScale.y, shapeOriginalScale.z), rotationSpeed / 2);

            if (movingToStandCounter > 70)
            {
                isMovingButtonRelease = false;
                isMovingToStandCounter = false;
                movingToStandCounter = 0;
                shapeMovingParticle.SetActive(false);
            }
        }
    }

    public void HitObstacle()
    {
        if (isHitObstacle)
        {
            shapeHealth--;

            hitTargetPosition.x = Random.Range(-4.0f, 4.0f);
            switch (Random.Range(1, 3))
            {
                case 1:
                    hitTargetPosition.y = Mathf.Abs(Mathf.Sqrt(16 - Mathf.Pow(hitTargetPosition.x, 2)));
                    break;
                case 2:
                    hitTargetPosition.y = -Mathf.Abs(Mathf.Sqrt(16 - Mathf.Pow(hitTargetPosition.x, 2)));
                    break;
            }

            shapeOriginalPosition = shapePlayer.transform.position;
            isHitIntoTarget = true;
            isLifeBubble = true;
            isHitObstacle = false;
        }

        if (isHitIntoTarget)
        {
            hittingCounter++;
            shapePlayer.transform.position = Vector3.Lerp(shapePlayer.transform.position, new Vector3(shapeOriginalPosition.x + hitTargetPosition.x, shapeOriginalPosition.y + hitTargetPosition.y, shapeOriginalPosition.z), 0.04f);

            if (hittingCounter > 20)
            {
                hittingCounter = 0;
                isHitIntoTarget = false;
            }
        }

        if (isLifeBubble)
        {
            lifeBubbleCounter += Time.deltaTime;

            if ((lifeBubbleCounter > 0) && (lifeBubbleCounter < 3))
            {
                shapePlayer.GetComponent<Animator>().SetBool("isLifeBubble", true); 
                shapePlayer.GetComponent<BoxCollider2D>().enabled = false;
            }

            if ((lifeBubbleCounter > 3))
            {
                shapePlayer.GetComponent<Animator>().SetBool("isLifeBubble", false);
                shapePlayer.GetComponent<BoxCollider2D>().enabled = true;
                lifeBubbleCounter = 0;
                isLifeBubble = false;
            }
        }

        if (shapeHealth == 3) shapePlayer.GetComponent<SpriteRenderer>().sprite = fullHealth;
        else if (shapeHealth == 2) shapePlayer.GetComponent<SpriteRenderer>().sprite = shape2Health;
        else if (shapeHealth == 1) shapePlayer.GetComponent<SpriteRenderer>().sprite = shape1Health;
    }

    public void CatchTriangleGoal()
    {
        if (isCatchGoal)
        {
            triangleGoalClass.transform.position = shapePlayer.transform.position;
            triangleGoalClass.GetComponent<Animator>().SetTrigger("ShapeCatchGoal");
            gameManager.GetComponent<AudioSource>().Stop();
            shapePlayer.GetComponent<AudioSource>().Play();

            gameManager.gameLevel++;

            isCatchGoal = false;
        }
    }
}
