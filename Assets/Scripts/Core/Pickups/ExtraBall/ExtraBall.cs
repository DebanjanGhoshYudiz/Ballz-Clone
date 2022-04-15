using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    public int ballSize;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ballSize++;
            Debug.Log(ballSize);
            FindObjectOfType<BallManager>().CreateBall(ballSize);
            Debug.Log("Created Ball");
            Destroy(gameObject);
        }
    }
}
