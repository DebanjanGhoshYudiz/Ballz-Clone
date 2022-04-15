using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "Scripts/Core/ScriptableObject/CoinData")]
public class CoinManager : ScriptableObject
{
    public int noOfCoinsCollected;
    
    public void SetCoins()
    {
        PlayerPrefs.SetInt("coins", noOfCoinsCollected);
    }

    public void GetCoins()
    {
        PlayerPrefs.GetInt("coins", noOfCoinsCollected);
    }
}
