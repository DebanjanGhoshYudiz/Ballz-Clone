using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D ballPrefab;
    [SerializeField] private SwipeController swipeControler;
    [SerializeField] private Spawner spawnerScript;
    [SerializeField] private GameplayScreen gameplayScreen;
    public int ballCounter;
    public float ballForce;
    public Vector2 mainBallPosition;
    public List<Rigidbody2D> balls;
    public bool isGameRunning = false;



    private void OnEnable()
    {
        // Subscribe Event which returns Vector 2 Direction
        swipeControler.Swipe += ThrowBall;
    }

    private void Start()
    {
        mainBallPosition = mainBall.transform.position;
    }


    public void CreateBall( int mainBallSize)
    {
        // Create ball when Extra ball pickup is taken by the Player.
        for (int i = 0; i < mainBallSize; i++)
        {
            Rigidbody2D prefab = Instantiate(ballPrefab, transform);
            prefab.gameObject.SetActive(false);
            prefab.transform.position = mainBall.transform.position;
            balls.Add(prefab);
        }
    }

    public void ThrowBall(Vector2 direction)
    {
        if (!isGameRunning)
        {
            StartCoroutine(MainThrowBall(direction));
            isGameRunning = true;
        }
    }

    public IEnumerator MainThrowBall(Vector2 direction)
    {
        ballCounter = 0; // Counter Reset
        for (int ball = 0; ball < balls.Count; ball++)
        {
            ballCounter++;
            balls[ball].gameObject.SetActive(true);
            balls[ball].constraints = RigidbodyConstraints2D.None;
            balls[ball].velocity = direction * ballForce;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void CollectBall(Rigidbody2D anotherBall)
    {
        if (anotherBall.gameObject != mainBall)
        {
            anotherBall.transform.position = mainBall.transform.position;
            anotherBall.gameObject.SetActive(false);
            ballCounter--;
            if (ballCounter == 0)
            {
                isGameRunning = false;
                spawnerScript.NextMove();
            }
        }
        else
        {
            ballCounter--;
            if (ballCounter == 0)
            {
                isGameRunning = false;
                spawnerScript.NextMove();
            }
        }
        
    }

    public void RemoveBall()
    {
        for (int ball = 0; ball < balls.Count; ball++)
        {
            if (balls[ball] != balls[0])
            {
                Destroy(balls[ball].gameObject);
                balls.Remove(balls[ball]);
            }
        }
    }

    public void FreezeBalls()
    {
        for (int ball = 0; ball < balls.Count; ball++)
        {
            if (balls[ball] != null)
            {
                balls[ball].constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    public void UnFreezeBalls()
    {
        for (int ball = 0; ball < balls.Count; ball++)
        {
            if (balls[ball] != null)
            {
                balls[ball].constraints = RigidbodyConstraints2D.None;
            }
        }
    }
    
    public void GiveVelocity()
    {
        for (int index = 0; index < balls.Count; index++)
        {
            balls[index].velocity = gameplayScreen.storeVelocity;
        }
    }

    private void OnDisable()
    {
        swipeControler.Swipe -= ThrowBall;
    }
}
