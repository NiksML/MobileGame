using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject _EndGamePanel;
    [SerializeField] private Text _textPlayerLoser;
    private void Start()
    {
        _EndGamePanel.SetActive(false);
    }

    private void Update()
    {
        if (PlayerController.gameEnd)
        {
            _EndGamePanel.SetActive(true);
            Time.timeScale = 0;
            _textPlayerLoser.text = "Player with id " + PlayerController.loserId.ToString() + " lost with " + PlayerController.instance.coins.ToString() + " coins";
        }
    }

    public void TryAgain()
    {
        PhotonNetwork.LoadLevel(0);
        Time.timeScale = 1;
    }


}
