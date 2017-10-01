using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Movement : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed = 7.5f;
    public float dodgeMult = 5f;
    public Boundary boundary;

    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate;
    private float nextFire;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        float moveH = Input.GetAxisRaw("Horizontal") * speed;
        float moveV = Input.GetAxisRaw("Vertical") * speed;

        Vector2 moveVec = new Vector2(moveH, moveV).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = moveVec * speed * dodgeMult;
        }
        else
        {
            rb2d.velocity = moveVec * speed;
        }

        rb2d.position = new Vector2
            (
                Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax) 
            );

    }
}
