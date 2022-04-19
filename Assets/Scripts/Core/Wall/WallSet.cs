using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class WallSet : MonoBehaviour
{
    public Transform upperWall;
    public Transform leftWall;
    public Transform rightWall;

    private void Start()
    {
        SetWalls(upperWall, leftWall, rightWall);
    }

    public void SetWalls(Transform wall1, Transform wall2, Transform wall3)
    {
        wall1.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f));
        wall2.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f));
        wall3.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f));
    }
}
