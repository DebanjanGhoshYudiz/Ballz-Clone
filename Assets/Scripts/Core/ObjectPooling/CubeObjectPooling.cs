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
    public List<PickUp> pickupPrefabs = new List<PickUp>();
    public List<PickUp> pickupList = new List<PickUp>();
    private PickUp prefab;
    


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

    private void Start()
    {
        AddPickups(2, Pickup.coin);
        AddPickups(2, Pickup.extraBall);
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
    public class PickUp
    {
        public Pickup pickEnum;
        public GameObject pickupPrefab;
    }

    public GameObject GetPickup(Pickup pickup)
    {
        prefab = pickupList.Find(x => x.pickEnum == pickup);
        if (prefab == null)
        {
            AddPickups(1, pickup);
            prefab = pickupList[pickupList.Count - 1];
            Debug.Log("Prefab name: " + prefab.pickupPrefab.name);
        }
        else
        {
            Debug.Log("Prefab name Not Null: " + prefab.pickupPrefab.name);
            pickupList.Remove(prefab);
        }
        return prefab.pickupPrefab;
    }

    public void AddPickups(int count, Pickup pickup)
    {
        for (int index = 0; index < count; index++)
        {
            GameObject prefab = pickupPrefabs.Find(x => x.pickEnum == pickup).pickupPrefab;
            GameObject instantiatedPrefab = Instantiate(prefab);
            instantiatedPrefab.gameObject.SetActive(false);
            PickUp data = new PickUp();
            data.pickEnum = pickup;
            data.pickupPrefab = instantiatedPrefab;
            pickupList.Add(data);
        }
    }

    public void PickupReturnToPool(GameObject pickupGO, Pickup pickup)
    {
        pickupGO.SetActive(false);
        pickupList.Add(new PickUp{pickEnum = pickup, pickupPrefab = pickupGO});
    }





}
