using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBeating : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void IntoBeatingMode()
    {
        this.GetComponent<Animator>().SetTrigger("IntoBeatingMode");
    }
}
