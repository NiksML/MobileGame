using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public static PlayerController instance;

    private Rigidbody2D _rb;
    private PhotonView _photonView;
    [SerializeField] private float _playerSpeed;
    public Joystick _joystick;
    //private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;
    //public float bulletForce = 20f;
    [SerializeField] private Text _playerName;
    //public bool isShooting;
    private int curHp;
    private static int maxHp = 25;
    [SerializeField] private Image _hpMass;
    public static bool gameEnd;
    public static int loserId = 9999;
    public int coins;
    [SerializeField] private Text _coinsText;
    //private Transform nameRotZ;


    void Start()
    {
        coins = 0;
        instance = this;
        gameEnd = false;
        curHp = maxHp;;
        _rb = GetComponent<Rigidbody2D>();
        _photonView = GetComponent<PhotonView>();
        _rb.gravityScale = 0;
        _joystick = (Joystick)GameObject.FindObjectOfType(typeof(Joystick));
        _playerName.text = "Player ID: " + _photonView.ViewID.ToString();
        
    }

    private void FixedUpdate()
    {
        
        

    }
    
    private void Update()
    { 
        _coinsText.text = "Coins: " + coins.ToString();
        transform.GetChild(1).rotation = Quaternion.identity;
        if (_photonView.IsMine)
        {
            PlayerMove();
        }
        else
        {
            return;
        }
    }

    private void PlayerMove()
    {
        
        float h = _joystick.Horizontal;
        float v = _joystick.Vertical;
        float z = Mathf.Atan2(h,v) * Mathf.Rad2Deg;
        _rb.velocity = new Vector2(h * _playerSpeed, v * _playerSpeed);
        
        Vector2 movement = _rb.velocity;
        if (movement != Vector2.zero)
        {
            transform.eulerAngles = new Vector3(0f, 0f, -z);
        }
        
    }


    /*public void PlayerShooting(bool _photonView)
    {
        _photonView = this._photonView.IsMine;
        if (_photonView)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "fireball"), transform.position, transform.rotation);
        }
                         
    }*/

    public void PlayerShooting()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "fireball"), transform.position, transform.rotation);
        
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            curHp--;
            Destroy(col.gameObject);
            Destroy(_hpMass.transform.GetChild(curHp).gameObject);
            print("Hp of player with ID:" + _photonView.ViewID.ToString() + " is " + curHp);
            if (curHp <= 0) 
            {
                loserId = _photonView.ViewID;
                gameEnd = true;
                
            }
        }
        if (col.gameObject.tag == "Coin")
        {
            coins++;
            Destroy(col.gameObject);
        }
    }
}
