using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("Cube")]
    [SerializeField] private CubeScript cubePrefab;
    private int _noOfRowSpawned;
    private int _levelCubeNumber;
    public List<CubeScript> cubesList;
    
    
    [Header("Coin Pickup")]
    [SerializeField] private GameObject coinPrefab;
    private int _coinLineSpawned = 0;
    private int _randomLineSpawned;
    public List<GameObject> pickupList;
    
    
    [Header("Extra ball Pickup")]
    [SerializeField] private GameObject extraBallPrefab;
    private int _extraBallLineSpawned;
    private int _randomExtraBallLineSpawned;

    [Header("Spawn Related")]
    [SerializeField] private float setYPos;
    [SerializeField] private float setXPos;
    private int _xSize;
    public float _cubeOffset;
    public float _cubeOffsetDown;
    
    [Header("Script Reference")]
    [SerializeField] private GameplayScreen gameplayScreen;


    [Header("AudioClip")]
    [SerializeField] private AudioClip nextLevelAudioClip;


    private void OnEnable()
    {
        GameEvents.ResetGame += ResetGameResetSpawn;
    }


    private void Start()
    {
        _noOfRowSpawned = 0;
        GenerateRandomCoinLine();
        GenerateRandomExtraBallLine();
        LineSpawner();
        _coinLineSpawned++;
        _extraBallLineSpawned++;
    }

    public void LineSpawner()
    {
        if (_coinLineSpawned == _randomLineSpawned)
        {
            _coinLineSpawned = 0;
            if (Random.Range(0, 100) >= 50)
            {
                Vector3 randomXPos = new Vector3(Random.Range(0,5), setYPos) * _cubeOffset;
                // GameObject anotherPrefab = Instantiate(coinPrefab, randomXPos, Quaternion.identity);
                // anotherPrefab.transform.position =
                //     new Vector3(anotherPrefab.transform.position.x + setXPos, anotherPrefab.transform.position.y);
                GameObject anotherPrefab = CubeObjectPooling.Instance.GetPickup(Pickup.coin);
                anotherPrefab.transform.position = randomXPos;
                anotherPrefab.gameObject.SetActive(true);
                pickupList.Add(anotherPrefab);
            }
            GenerateRandomCoinLine();
        }
        else if (_extraBallLineSpawned == _randomExtraBallLineSpawned)
        {
            _extraBallLineSpawned = 0;
            if (Random.Range(0, 100) >= 50)
            {
                Vector3 randomXPos = new Vector3(Random.Range(0, 5), setYPos) * _cubeOffset;
                // GameObject anotherPrefab = Instantiate(extraBallPrefab, randomXPos, Quaternion.identity);
                // anotherPrefab.transform.position =
                //     new Vector3(anotherPrefab.transform.position.x + setXPos, anotherPrefab.transform.position.y);
                GameObject anotherPrefab = CubeObjectPooling.Instance.GetPickup(Pickup.extraBall);
                anotherPrefab.transform.position = randomXPos;
                anotherPrefab.gameObject.SetActive(true);
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
                    Vector3 setRandomXPos = new Vector3(x + setXPos, setYPos) * _cubeOffset;
                    CubeScript prefab = CubeObjectPooling.Instance.Get();
                    prefab.transform.position = setRandomXPos;
                    prefab.gameObject.SetActive(true);
                    // prefab.transform.position =
                    //     new Vector3(prefab.transform.position.x + setXPos, prefab.transform.position.y);
                    _levelCubeNumber = Random.Range(1, 3) + _noOfRowSpawned;
                    prefab.UpdateCubeNumber(_levelCubeNumber);
                    cubesList.Add(prefab);
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
        LineSpawner();
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

    public void ResetGameResetSpawn()
    {
        for (int i = 0; i < cubesList.Count; i++)
        {
            if (cubesList[i] != null)
            {
                Debug.Log("Cubes Return to pool!");
                //Destroy(cubesList[i].gameObject);
                CubeObjectPooling.Instance.ReturnToPool(cubesList[i]);
            }
        }
        cubesList.Clear();

        for (int i = 0; i < pickupList.Count; i++)
        {
            if (pickupList[i] != null)
            {
                //Destroy(pickupList[i]);
                CubeObjectPooling.Instance.PickupReturnToPool(pickupList[i]);
            }
        }
        pickupList.Clear();
        _noOfRowSpawned = 0;
        _coinLineSpawned = 0;
        GenerateRandomCoinLine();
        GenerateRandomExtraBallLine();
        LineSpawner();
        _coinLineSpawned++;
        _extraBallLineSpawned++;
    }

    public void RemoveCube(CubeScript cube)
    {
        cubesList.Remove(cube);
    }

    public void RemovePickup(GameObject pickup)
    {
        pickupList.Remove(pickup);
    }
    

    private void OnDisable()
    {
        GameEvents.ResetGame -= ResetGameResetSpawn;
    }
}


// Decide Spawn.
// Random Next (Unquie Random numbers). 
// 

