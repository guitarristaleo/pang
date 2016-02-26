﻿using UnityEngine;
using System.Collections;

public class ParabolaBehaviour2 : MonoBehaviour {

    public float xSpeed = 2f;
    public float ySpeed = 1f;
    private float acceleration = -0.5f;
    public GameObject pelota1, pelota2;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
        ySpeed += acceleration;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            ySpeed *= -1;
        }
        if (col.gameObject.tag == "Pared")
        {
            xSpeed *= -1;
        }
        /*if (col.gameObject.tag == "Plataforma")
        {

        }*/

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Disparo")
        {
            Destroy(this.gameObject);

            Instantiate(pelota2, transform.position, Quaternion.identity);
            pelota2.GetComponent<ParabolaBehaviour>().xSpeed = 2f;

            Instantiate(pelota1, transform.position, Quaternion.identity);
            pelota1.GetComponent<ParabolaBehaviour>().xSpeed = -2f;            
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "suelo")
        {
            ySpeed = 1f;
        }
    }
}
