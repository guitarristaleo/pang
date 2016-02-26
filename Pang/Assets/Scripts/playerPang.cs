using UnityEngine;
using System.Collections;

public class playerPang : MonoBehaviour
{

    public float fuerzaSalto = 5;
    public float fuerzaLateral = 5;
    public float velocidadMaxima = 5;
    public int puntos = 0;
    public GameObject disparo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
            //GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto);
            Instantiate(disparo, new Vector3(transform.position.x, -8.03f, 0.31f), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(fuerzaLateral, GetComponent<Rigidbody2D>().velocity.y);
            //GetComponent<Rigidbody2D>().AddForce(Vector2.right * fuerzaLateral);
            //if(GetComponent<Rigidbody2D>().velocity.x > velocidadMaxima)
            //{
            //    GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMaxima, GetComponent<Rigidbody2D>().velocity.y);
            //}
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * fuerzaLateral, GetComponent<Rigidbody2D>().velocity.y);
            //GetComponent<Rigidbody2D>().AddForce(Vector2.left * fuerzaLateral);
            //if (GetComponent<Rigidbody2D>().velocity.x < -velocidadMaxima)
            //{
            //    GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadMaxima, GetComponent<Rigidbody2D>().velocity.y);
            //}
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        
    }
}
