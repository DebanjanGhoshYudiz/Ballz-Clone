using System;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private CoinManager coinManagerScriptableObj;
    [SerializeField] private AudioClip coinSfxAudioClip;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            coinManagerScriptableObj.noOfCoinsCollected++;
            AudioManager.instance.PlaySfx(coinSfxAudioClip);
            Debug.Log(coinManagerScriptableObj.noOfCoinsCollected);
            coinManagerScriptableObj.updateCoin?.Invoke();
            Destroy(gameObject);
        }
    }
}
