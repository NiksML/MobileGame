using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomList : MonoBehaviour
{
    [SerializeField] private Text roomName;

    public RoomInfo info;

    public void SetUp(RoomInfo roomInfo)
    {
        info = roomInfo;
        roomName.text = info.Name;
    }

    public void OnClick()
    {
        
            Launcher.instance.JoinRoom(info);
        
        
    }
}
