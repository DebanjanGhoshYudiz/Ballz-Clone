using System;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private CoinManager coinManagerScriptableObj;
    [SerializeField] private AudioClip coinSfxAudioClip;
    private Spawner _spawnerScript;

    private void Start()
    {
        _spawnerScript = FindObjectOfType<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            coinManagerScriptableObj.noOfCoinsCollected++;
            AudioManager.instance.PlaySfx(coinSfxAudioClip);
            Debug.Log(coinManagerScriptableObj.noOfCoinsCollected);
            coinManagerScriptableObj.updateCoin?.Invoke();
            CubeObjectPooling.Instance.CoinReturnToPool(this.gameObject);
            _spawnerScript.RemovePickup(this.gameObject);
        }
    }
}
