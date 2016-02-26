using UnityEngine;
using System.Collections;

public class DestruirPelota : MonoBehaviour
{

    public float xSpeed = 2f;
    public float ySpeed = 1f;
    private float acceleration = -0.5f;

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
