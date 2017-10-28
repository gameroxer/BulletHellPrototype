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
    public float Speed = 5;
    public float DashMult = 5f;
    public float DashDuration = 1f;
    public Boundary boundary;

    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate;
    private float nextFire;

    private bool invulnerable;
    private ParticleSystem particles;
    private float dashMult = 1;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        invulnerable = false;
        particles = GetComponent<ParticleSystem>();
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
        float moveH = Input.GetAxisRaw("Horizontal") * Speed;
        float moveV = Input.GetAxisRaw("Vertical") * Speed;

        Vector2 moveVec = new Vector2(moveH, moveV).normalized;

        //If player inputs Spacebar during movement, dash in the current moving direction
        //Otherwise, move at normal speed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash(moveVec));
        }

        rb2d.velocity = moveVec * Speed * dashMult;

        //Clamps player position so if you try to move outside the screen you can't
        rb2d.position = new Vector2
            (
                Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax) 
            );

    }

    public IEnumerator Dash(Vector2 moveVec)
    {
        dashMult = DashMult;
        invulnerable = true;
        particles.Play();

        //Wait for however many seconds before setting the dash back to normal
        yield return new WaitForSeconds(DashDuration);

        dashMult = 1f;
        invulnerable = false;
        particles.Pause();
        particles.Clear();

    }

    //If player collides with enemy bullet or enemy, destroys player
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!invulnerable && (other.name == "EnemyBullet(Clone)" || other.name == "Enemy1(Clone)"))
        {
            Destroy(this.gameObject);
        }
    }
}
