using UnityEngine;
using System.Collections;

public class ParabolaBehaviour2 : MonoBehaviour {

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
            pelota2.GetComponent<DestruirPelota>().xSpeed = 2f;
            playerPang.pelotaS++;

            Instantiate(pelota1, transform.position, Quaternion.identity);
            pelota1.GetComponent<DestruirPelota>().xSpeed = -2f;
            playerPang.pelotaS++;

            Destroy(this.gameObject);
            playerPang.pelotaM--;
            playerPang.score += 800;
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
