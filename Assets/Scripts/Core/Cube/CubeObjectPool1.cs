using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeObjectPool : MonoBehaviour
{
    [Header("Cube")]
    [SerializeField] private CubeScript cubePrefab;
    private int _noOfRowSpawned;
    private int _levelCubeNumber;
    private CubeScript _prefab;
    public List<CubeScript> cubesList;
    
    
    [Header("Coin Pickup")]
    [SerializeField] private GameObject coinPrefab;
    private int _coinLineSpawned;
    private int _randomLineSpawned;
    public List<GameObject> pickupList;
    
    
    [Header("Extra ball Pickup")]
    [SerializeField] private GameObject extraBallPrefab;
    private int _extraBallLineSpawned;
    private int _randomExtraBallLineSpawned;

    [Header("Spawn Related")]
    [SerializeField] private float setYPos;
    [SerializeField] private float setXPos;
    [SerializeField] private Transform cubeHolder;
    private int _xSize;
    public float _cubeOffset;
    public float _cubeOffsetDown;
    
    [Header("Script Reference")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameplayScreen gameplayScreen;
    
    
    [Header("AudioClip")]
    [SerializeField] private AudioClip nextLevelAudioClip;
   
    


    private void Start()
    {
        _noOfRowSpawned = 0;
        CubeSpawner();
        _coinLineSpawned++;
        _extraBallLineSpawned++;
        GenerateRandomCoinLine();
        GenerateRandomExtraBallLine();
    }

    public void CubeSpawner()
    {
        if (_coinLineSpawned == _randomLineSpawned)
        {
            _coinLineSpawned = 0;
            if (Random.Range(0, 100) >= 10)
            {
                Vector3 randomXPos = new Vector3(Random.Range(0,5), setYPos) * _cubeOffset;
                GameObject anotherPrefab = Instantiate(coinPrefab, randomXPos, Quaternion.identity, cubeHolder);
                anotherPrefab.transform.position =
                    new Vector3(anotherPrefab.transform.position.x + setXPos, anotherPrefab.transform.position.y);
                pickupList.Add(anotherPrefab);
            }
            GenerateRandomCoinLine();
        }
        else if (_extraBallLineSpawned == _randomExtraBallLineSpawned)
        {
            _extraBallLineSpawned = 0;
            if (Random.Range(0, 100) >= 10)
            {
                Vector3 randomXPos = new Vector3(Random.Range(0, 5), setYPos) * _cubeOffset;
                GameObject anotherPrefab = Instantiate(extraBallPrefab, randomXPos, Quaternion.identity, cubeHolder);
                anotherPrefab.transform.position =
                    new Vector3(anotherPrefab.transform.position.x + setXPos, anotherPrefab.transform.position.y);
                pickupList.Add(anotherPrefab);
            }
            GenerateRandomExtraBallLine();
        }
        else
        {
            _xSize = 5;
            for (int x = 0; x < _xSize; x++)
            {
                if (Random.Range(0, 100) >= 50)
                {
                    Vector3 randomXPos = new Vector3(x, setYPos) * _cubeOffset;
                    _prefab = Instantiate(cubePrefab, randomXPos, Quaternion.identity, cubeHolder);
                    _prefab.transform.position =
                        new Vector3(_prefab.transform.position.x + setXPos, _prefab.transform.position.y);
                    _levelCubeNumber = Random.Range(1, 3) + _noOfRowSpawned;
                    _prefab.UpdateCubeNumber(_levelCubeNumber);
                    cubesList.Add(_prefab);
                }
                GenerateRandomCoinLine();
            }
            _noOfRowSpawned++;
        }
    }


    
    //decide spawn

    public void NextMove()
    {
        for (int i = 0; i < cubesList.Count; i++)
        {
            if (cubesList[i] != null)
                cubesList[i].transform.position -= new Vector3(0, -1.5f) * _cubeOffsetDown;
        }
        
        for (int i = 0; i < pickupList.Count; i++)
        {
            if (pickupList[i] != null)
                pickupList[i].transform.position -= new Vector3(0, -1.5f) * _cubeOffsetDown;
        }
        
        AudioManager.instance.PlaySfx(nextLevelAudioClip);
        gameplayScreen.UpdateScore();
        CubeSpawner();
        _coinLineSpawned++;
        _extraBallLineSpawned++;
    }

    public void GenerateRandomCoinLine()
    {
        int randomLine = Random.Range(2, 5);
        _randomLineSpawned = randomLine;
    }

    public void GenerateRandomExtraBallLine()
    {
        int randomLine = Random.Range(2, 5);
        _randomExtraBallLineSpawned = randomLine;
    }
    
}


// Decide Spawn.
// Random Next (Unquie Random numbers). 
// 
