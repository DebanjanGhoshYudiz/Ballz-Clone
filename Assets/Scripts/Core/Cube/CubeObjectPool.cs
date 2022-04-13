using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TreeEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class CubeObjectPool : MonoBehaviour
{
    public int noOfCubes;
    public float cubeOffset;
    public float cubeOffsetDown;
    public List<GameObject> cubes;
    public GameObject cubePrefab;
    public GameObject prefab;
    public Transform cubeHolder;
    public float gridX;
    public float gridY;
    public float radius;

    private void Start()
    {
        CubeSpawner();
    }

    public void CubeSpawner()
    {
        for (int x = 0; x < gridY; x++)
        {
            Vector3 newPos = new Vector3(Random.Range(0, 5) + -1.96f, 2.40f) * cubeOffset;
            if (Physics2D.OverlapCircle(newPos, radius) == null)
            {
                prefab = Instantiate(cubePrefab, newPos, Quaternion.identity, cubeHolder);
                cubes.Add(prefab);
            }
            //prefab.SetActive(false);
            //cubes.Add(prefab);
        }
    }

    public void NextMove()
    {
        for (int cube = 0; cube < cubes.Count; cube++)
        {
            cubes[cube].transform.position =
                new Vector2(cubes[cube].transform.position.x, cubes[cube].transform.position.y + cubeOffsetDown);
            cubes.Remove(cubes[cube]);
        }
        CubeSpawner();
    }
}


