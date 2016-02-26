using UnityEngine;
using System.Collections;

public class DisparoBehaviour : MonoBehaviour {
    private float xSpeed = 0f;
    private float ySpeed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Techo")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Bola")
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Techo")
        {
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Bola")
        {
            Destroy(this.gameObject);
        }
    }
}
