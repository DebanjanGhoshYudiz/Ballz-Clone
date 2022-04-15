using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<Rigidbody2D> balls;
    public Rigidbody2D ballPrefab;
    public int size;
    public float ballForce;
    public int ballCounter;
    public SwipeController swipeControler;
    public CubeObjectPool cubeObjectPool;
    public GameObject mainBall;


    private void OnEnable()
    {
        swipeControler.Swipe += ThrowBall;
    }

    private void Start()
    {
        CreateBall(size);
    }

    public void CreateBall( int mainBallSize)
    {
        for (int i = 0; i < mainBallSize; i++)
        {
            Rigidbody2D prefab = Instantiate(ballPrefab, transform);
            prefab.gameObject.SetActive(true);
            balls.Add(prefab);
        }
    }

    public void ThrowBall(Vector2 direction)
    {
        StartCoroutine(MainThrowBall(direction));
    }

    public IEnumerator MainThrowBall(Vector2 direciton)
    {
        ballCounter = 0; // Reset
        foreach (Rigidbody2D ball in balls)
        {
            ballCounter++;
            ball.gameObject.SetActive(true);
            ball.constraints = RigidbodyConstraints2D.None;
            ball.AddForce(direciton * ballForce, ForceMode2D.Force);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void CollectBall(Rigidbody2D anotherBall)
    {
        anotherBall.gameObject.SetActive(false);
        ballCounter--;
        if (ballCounter == 0)
        {
            cubeObjectPool.NextMove();
        }
        Debug.Log(ballCounter);
    }

    private void OnDisable()
    {
        swipeControler.Swipe += ThrowBall;
    }
}
