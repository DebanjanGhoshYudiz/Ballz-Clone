using System;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public CoinManager coinManagerScriptableObj;
    public AudioClip coinSfxAudioClip;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            coinManagerScriptableObj.noOfCoinsCollected++;
            AudioManager.instance.PlaySfx(coinSfxAudioClip);
            Debug.Log(coinManagerScriptableObj.noOfCoinsCollected);
            Destroy(gameObject);
        }
    }
}
