using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direct;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rigidbody2D.velocity = Direct * speed;
    }

    public void SetDirection(Vector2 direct)
    {
        Direct = direct;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
