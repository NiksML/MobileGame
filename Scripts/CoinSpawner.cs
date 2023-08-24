using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "coinPrefab"), new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        StartCoroutine(Spawner());
    }

}
