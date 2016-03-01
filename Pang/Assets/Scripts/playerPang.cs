using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerPang : MonoBehaviour
{

    public float fuerzaSalto = 5;
    public float fuerzaLateral = 5;
    public float velocidadMaxima = 5;
    public int puntos = 0;
    public GameObject disparo;
    public static bool heDisparado = false;
    public static int pelotaL, pelotaM, pelotaS;
    public static int score;
    public bool moverIzq = true;
    public bool moverDer = true;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        score = 0;
        pelotaL = 1;
        pelotaM = 1;
        pelotaS = 1;
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

        if(Input.GetKey(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0.0f;
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1f;
            }
        }

        if(pelotaS == 0 && pelotaM == 0 && pelotaL == 0)
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
                pelotaL = 1;
            }
            else if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("Has Ganado! Tu puntuación es: " + score);
                Time.timeScale = 0.0f;
            }
            
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
