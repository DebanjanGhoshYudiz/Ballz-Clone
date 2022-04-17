using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeObjectPool : MonoBehaviour
{
    public int xSize;
    public float cubeOffset;
    public float cubeOffsetDown;
    public List<CubeScript> cubesList;
    public CubeScript cubePrefab;
    public CubeScript prefab;
    public Transform cubeHolder;
    public float setYPos;
    public float setXPos;
    public ScoreManager scoreManager;
    public System.Random rand = new System.Random();
    public int noOfRowSpawned;


    private void Start()
    {
        CubeSpawner();
    }

    public void CubeSpawner()
    {
        xSize = 5;
        for (int x = 0; x < xSize; x++)
        {
            if (Random.Range(0, 100) >= 50)
            {
                Vector3 randomXPos = new Vector3(x, setYPos) * cubeOffset;
                prefab = Instantiate(cubePrefab, randomXPos, Quaternion.identity, cubeHolder);
                prefab.transform.position = new Vector3(prefab.transform.position.x + setXPos, prefab.transform.position.y);
                int levelCubeNumber = Random.Range(1, 2) + noOfRowSpawned;
                prefab.UpdateCubeNumber(levelCubeNumber);
                cubesList.Add(prefab);
            }

            noOfRowSpawned++;
        }
        
        

    }

    public void NextMove()
    {
        for (int cube = 0; cube < cubesList.Count; cube++)
        {
            if (cubesList[cube] != null)
            {
                cubesList[cube].transform.position -= new Vector3(0, -1.5f) * cubeOffsetDown;
            }
        }
        scoreManager.score++;
        CubeSpawner();
    }
    
}


// Decide Spawn.
// Random Next (Unquie Random numbers). 
// 

