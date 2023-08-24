using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    [SerializeField] private GameObject _startPos;

    void Start()
    {
        _startPos = GameObject.Find("torch1");
        transform.position = _startPos.transform.position;
        transform.rotation = _startPos.transform.rotation;
    }


    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        if(transform.position.x < -11 || transform.position.x > 11 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
