using System.Collections;
using UnityEngine;

public class ParabolaBehaviour : MonoBehaviour
{
    public float xSpeed = 2f;
    public float ySpeed = 1f;
    private float acceleration = -0.3f;
    public GameObject pelota1;
    public GameObject pelota2;

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
        if (col.gameObject.tag == "Disparo")
        {
            Instantiate(pelota2, transform.position, Quaternion.identity);
            pelota2.GetComponent<ParabolaBehaviour2>().xSpeed = 2f;
            playerPang.pelotaM++;

            Instantiate(pelota1, transform.position, Quaternion.identity);
            pelota1.GetComponent<ParabolaBehaviour2>().xSpeed = -2f;
            playerPang.pelotaM++;

            Destroy(this.gameObject);
            playerPang.pelotaL--;
            playerPang.score += 400;
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
