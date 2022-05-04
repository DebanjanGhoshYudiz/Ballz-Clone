using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    private BallManager _ballManager;
    private Spawner _spawnerScirpt;
    public int ballSize;

    private void Start()
    {
        _ballManager = FindObjectOfType<BallManager>();
        _spawnerScirpt = FindObjectOfType<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ballSize++;
            Debug.Log(ballSize);
            _ballManager.CreateBall(ballSize);
            Debug.Log("Created Ball");
            //Destroy(this.gameObject);
            CubeObjectPooling.Instance.PickupReturnToPool(this.gameObject);
            _spawnerScirpt.RemovePickup(this.gameObject);
        }
    }
}
