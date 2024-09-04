using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleGoal : MonoBehaviour
{
    public ShapeController controller;
    public GameManager gameManager;

    private GameObject goal;
    public GameObject triangle;
    public GameObject smallRing;
    public GameObject largeRing;

    public int triangleMovementCounter;

    public float rotationSpeed = 5;

    public bool canTriangleCounter = true;


    void Awake()
    {
        goal = gameObject;
    }

    public void DestroyGoalAfterCatching()
    {
        goal.transform.position = new Vector3(11, 0, goal.transform.position.z);
        controller.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Animator>().SetTrigger("ShapeReturnNormal");
        gameManager.doGoalTimer = true;
    }

    public void CatchGoal()
    {
        gameManager.isLevelStart = true;
        goal.GetComponent<CircleCollider2D>().enabled = false;
    }
}
