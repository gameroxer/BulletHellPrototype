using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script moves a bullet object up at the speed specified

public class BulletMove : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0,speed);
    }
}
