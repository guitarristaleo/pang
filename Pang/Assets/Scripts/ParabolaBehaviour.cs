using System.Collections;
using UnityEngine;

public class ParabolaBehaviour : MonoBehaviour
{
    private float xSpeed = 2f;
    private float ySpeed = 1f;
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
            Instantiate(pelota1, transform.position, Quaternion.identity);
            pelota1.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
            pelota1.GetComponent<Transform>().localScale = new Vector2(0.7f, 0.7f);

            Instantiate(pelota2, transform.position, Quaternion.identity);
            pelota2.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
            pelota2.GetComponent<Transform>().localScale = new Vector2(0.7f, 0.7f);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "suelo")
        {
            ySpeed = 1f;
        }
    }
}
