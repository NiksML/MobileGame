using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerList : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text playerName;
    public static PlayerList instance;
    public static int  countPlayers;
    private Player _player;

    private void Start()
    {
        instance = this;
        countPlayers = 0;
    }
    public void SetUp(Player player)
    {
        _player = player;
        playerName.text = player.NickName;
        countPlayers++;
        print(countPlayers);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(_player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }
    
    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
