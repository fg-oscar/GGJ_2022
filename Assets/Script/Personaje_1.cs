using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje_1 : MonoBehaviour
{
    public GameObject Bullet;
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private float Horiz;
    private bool Grounded;
    private float lastshoot;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horiz = Input.GetAxisRaw("Horizontal");

        if (Horiz < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if(Horiz >0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //Debug.DrawRay(transform.position, Vector3.down * 0.9f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.9f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.Space) && Time.time > lastshoot + 0.25f)
        {
            Shoot();
            lastshoot = Time.time;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 directi;

        if (transform.localScale.x == 1.0f) directi = Vector3.right;
        else directi = Vector3.left;

        GameObject bullet = Instantiate(Bullet, transform.position + directi * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(directi);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horiz * Speed, Rigidbody2D.velocity.y);
    }
}
