using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    private PhotonView _photonView;
    
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if(_photonView.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), new Vector3(Random.Range(-10,10), Random.Range(-4, 4),0), Quaternion.identity);
    }
}
