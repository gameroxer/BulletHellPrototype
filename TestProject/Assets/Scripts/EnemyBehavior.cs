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

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -speed);
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bullet(Clone)")
        {
            Destroy(this.gameObject);
        }
    }

}
