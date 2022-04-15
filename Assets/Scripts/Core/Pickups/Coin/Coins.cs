using System;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public CoinManager coinManagerScriptableObj;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            coinManagerScriptableObj.noOfCoinsCollected++;
            Debug.Log(coinManagerScriptableObj.noOfCoinsCollected);
            Destroy(gameObject);
        }
    }
}
