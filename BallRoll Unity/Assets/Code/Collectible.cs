using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //this is a reserved type of code--i.e. we didn't have to write it ourselves
    {
        SoundManager.Instance.PlayCollectSound();
        CollectibleManager.Instance.IncrementCollectedCoinCount();
        Destroy(gameObject);
        print("collect coin");
    }
}
