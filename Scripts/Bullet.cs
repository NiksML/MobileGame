using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    
    private Transform pivot;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        if(transform.position.x < -11 || transform.position.x > 11 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    public void SetPivot(Transform pivot)
    {
        this.pivot = pivot;
        
        transform.position = pivot.position;
        transform.rotation = pivot.rotation;
    }
}
