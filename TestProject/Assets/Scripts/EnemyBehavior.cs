using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate;
    private float nextFire;

    //When enemy is instantiated, it will start moving downwards at specified speed
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -speed);
    }

    private void Update()
    {
        //Same as player firing except does not rely on keypress, just fire rate
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    //If hit by player bullet, destroy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bullet(Clone)")
        {
            Destroy(this.gameObject);
        }
    }

}
