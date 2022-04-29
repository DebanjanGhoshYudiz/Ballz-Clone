using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    
    [SerializeField] private GameObject mainBall;
    [SerializeField] private SwipeController swipeControler;
    [SerializeField] private Spawner spawnerScript;
    public int ballCounter;
    private Rigidbody2D tmpBallRb2D;
    public float ballForce;
    public Vector2 mainBallPosition;
    public List<Rigidbody2D> balls;
    public bool isGameRunning = true;
    public List<Vector2> storeVelocity;
    private Rigidbody2D mainBallRb2D;



    private void OnEnable()
    {
        // Subscribe Event which returns Vector 2 Direction
        swipeControler.Swipe += ThrowBall;
        GameEvents.ResetGame += GameplayOverRestart;
        GameEvents.onResume += GameplayPauseToResume;
        GameEvents.onGameOver += FreezeBalls;
        GameEvents.onGameplayPause += GameplayToPause;
        GameEvents.onPlay += GameStart;
    }

    private void Start()
    {
        mainBallPosition = mainBall.transform.position;
        mainBallRb2D = mainBall.GetComponent<Rigidbody2D>();
        mainBallRb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void GameStart()
    {
        isGameRunning = false;
    }
    


    public void CreateBall( int mainBallSize)
    {
        // Create ball when Extra ball pickup is taken by the Player.
        for (int i = 0; i < mainBallSize; i++)
        {
            Rigidbody2D prefab = CubeObjectPooling.Instance.GetBalls();
            prefab.gameObject.SetActive(true);
            prefab.transform.position = mainBallPosition;
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
        for (int index = 0; index < balls.Count; index++)
        {
            if (index >= 1)
            {
                CubeObjectPooling.Instance.BallReturnToPool(balls[index]);
            }
            else if (index == 0)
            {
                tmpBallRb2D = balls[0];
            }
        }
        balls.Clear();
        balls.Add(tmpBallRb2D);
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
            balls[index].velocity = storeVelocity[index];
        }
        storeVelocity.Clear();
    }

    public void StoreVelocity()
    {
        for (int index = 0; index < balls.Count; index++)
        {
            storeVelocity.Add(balls[index].velocity);
        }
    }

    public void GameplayOverRestart()
    {
        mainBall.transform.position = mainBallPosition;
        RemoveBall();
    }

    public void GameplayPauseToResume()
    {
        UnFreezeBalls();
        GiveVelocity();
    }

    public void GameplayToPause()
    {
        StoreVelocity();
        FreezeBalls();
    }

    private void OnDisable()
    {
        swipeControler.Swipe -= ThrowBall;
        GameEvents.ResetGame -= GameplayOverRestart;
        GameEvents.onResume -= GameplayPauseToResume;
        GameEvents.onGameOver -= FreezeBalls;
        GameEvents.onGameplayPause -= GameplayToPause;
    }
}
