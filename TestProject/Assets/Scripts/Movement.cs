using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script defines player movement/control

[System.Serializable]
public class Boundary
{
    //Defines boundary for player movement
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
        //If player inputs Fire1, if time is greater than fire interval, creates bullet
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

        //If player inputs Spacebar during movement, dash in the current moving direction
        //Otherwise, move at normal speed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = moveVec * speed * dodgeMult;
        }
        else
        {
            rb2d.velocity = moveVec * speed;
        }

        //Clamps player position so if you try to move outside the screen you can't
        rb2d.position = new Vector2
            (
                Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax) 
            );

    }

    //If player collides with enemy bullet or enemy, destroys player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "EnemyBullet(Clone)" || other.name == "Enemy1(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
}
