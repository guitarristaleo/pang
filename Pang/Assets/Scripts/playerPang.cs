using UnityEngine;
using System.Collections;

public class playerPang : MonoBehaviour
{

    public float fuerzaSalto = 5;
    public float fuerzaLateral = 5;
    public float velocidadMaxima = 5;
    public int puntos = 0;
    public GameObject disparo;
    public static bool heDisparado = false;
    public bool moverIzq = true;
    public bool moverDer = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Disparo
        if (Input.GetKeyDown(KeyCode.Space) && !heDisparado)
        {
            Instantiate(disparo, new Vector3(transform.position.x, -8.03f, 0.31f), Quaternion.identity);
            heDisparado = true;
        }
        //Movimiento a derecha
        if (Input.GetKey(KeyCode.RightArrow) )
        {
            if(moverDer)
                GetComponent<Rigidbody2D>().velocity = new Vector2(fuerzaLateral, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        //Movimiento a izquierda
        if (Input.GetKey(KeyCode.LeftArrow) && moverIzq)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * fuerzaLateral, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Pared")
        {
            moverIzq = false;
        }
        if (collider.gameObject.tag == "ParedDer")
        {
            moverDer = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Pared")
        {
            moverIzq = true;
        }
        if (collider.gameObject.tag == "ParedDer")
        {
            moverDer = true;
        }
    }
}
