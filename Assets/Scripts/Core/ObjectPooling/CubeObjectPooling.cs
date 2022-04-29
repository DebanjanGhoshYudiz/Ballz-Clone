using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeObjectPooling : MonoBehaviour
{
    public static CubeObjectPooling Instance { get; private set; }
    
    [Header("Cube")]
    public CubeScript cubePrefab;
    public Queue<CubeScript> cubeQueue = new Queue<CubeScript>();
    public int noOfObjectsToPool;
    public GameObject cubePrefabHolder;
    
    [Header("Coin")]
    public GameObject coinPrefab;
    public Queue<GameObject> coinQueue = new Queue<GameObject>();
    public int noOfCoinToPool;
    public GameObject pickupHolder;

    [Header("ExtraBall")] 
    public GameObject extraBallPrefab;
    public Queue<GameObject> extraBallQueue = new Queue<GameObject>();
    public int noOfExtraBallToPool;

    [Header("Ball")] 
    public Rigidbody2D ballPrefab;
    public Queue<Rigidbody2D> ballQueue = new Queue<Rigidbody2D>();
    public int noOfBallToPool;
    public GameObject ballPrefabHolder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType(typeof(CubeObjectPooling)) as CubeObjectPooling;
        }
        else
        {
            Instance = this;
        }
    }

    // Cube
    public CubeScript Get()
    {
        if (cubeQueue.Count == 0)
        {
            AddObject(noOfObjectsToPool);
        }

        return cubeQueue.Dequeue();
    }

    public void AddObject(int count)
    {
        for (int cube = 0; cube < count; cube++)
        {
            CubeScript prefab = Instantiate(cubePrefab, cubePrefabHolder.transform);
            prefab.gameObject.SetActive(false);
            cubeQueue.Enqueue(prefab);
        }
    }

    public void ReturnToPool(CubeScript cube)
    {
        cube.gameObject.SetActive(false);
        cubeQueue.Enqueue(cube);
    }
    
    
    
    // Ball
    public Rigidbody2D GetBalls()
    {
        if (ballQueue.Count == 0)
        {
            AddObjectBall(noOfBallToPool);
        }

        return ballQueue.Dequeue();
    }

    public void AddObjectBall(int count)
    {
        for (int ball = 0; ball < count; ball++)
        {
            Rigidbody2D prefab = Instantiate(ballPrefab, ballPrefabHolder.transform);
            prefab.gameObject.SetActive(false);
            ballQueue.Enqueue(prefab);
        }
    }

    public void BallReturnToPool(Rigidbody2D ball)
    {
        ball.gameObject.SetActive(false);
        ballQueue.Enqueue(ball);
    }

}
