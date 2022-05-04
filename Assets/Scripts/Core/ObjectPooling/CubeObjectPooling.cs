using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CubeObjectPooling : MonoBehaviour
{
    public static CubeObjectPooling Instance { get; private set; }
    
    [Header("Cube")]
    public CubeScript cubePrefab;
    public Queue<CubeScript> cubeQueue = new Queue<CubeScript>();
    public int noOfObjectsToPool;
    public GameObject cubePrefabHolder;

    [Header("Ball")] 
    public Rigidbody2D ballPrefab;
    public Queue<Rigidbody2D> ballQueue = new Queue<Rigidbody2D>();
    public int noOfBallToPool;
    public GameObject ballPrefabHolder;

    [Header("Pickup")] 
    public List<PickupContent> pickupList;
    public Queue<GameObject> pickupQueue = new Queue<GameObject>();

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
    
    //Pickup
    [System.Serializable]
    public class PickupContent
    {
        public Pickup pickupEnum;
        public GameObject prefabPickup;
    }

    public GameObject GetPickup(Pickup pickup)
    {
        if (pickupQueue.Count == 0)
        {
            AddObjectsPickup(1, pickup);
        }

        return pickupQueue.Dequeue();
    }

    public void AddObjectsPickup(int count, Pickup pickup)
    {
        for (int index = 0; index < count; index++)
        {
            GameObject findObj = pickupList.Find(x => x.pickupEnum == pickup).prefabPickup;
            GameObject prefab = Instantiate(findObj);
            prefab.gameObject.SetActive(false);
            pickupQueue.Enqueue(prefab);
        }
    }

    public void PickupReturnToPool(GameObject pickupGo)
    {
        pickupGo.gameObject.SetActive(false);
        pickupQueue.Enqueue(pickupGo);
    }

   

}
