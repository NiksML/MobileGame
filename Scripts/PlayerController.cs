using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _cameraSens;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Canvas _canvas;
    public Joystick _joystick;
    private float _rotationZ;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }
    // Update is called once per frame
    private void Update()
    {
        
    }

    private void PlayerMove()
    {
        
        float h = _joystick.Horizontal;
        float v = _joystick.Vertical;
        _rb.velocity = new Vector2(h * _playerSpeed, v * _playerSpeed);
    }
}
