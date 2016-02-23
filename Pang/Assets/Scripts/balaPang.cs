using UnityEngine;
using System.Collections;

public class balaPang : MonoBehaviour {

    public bool disparado = false;
    public float velocidad = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(disparado)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidad);
        }
	}
}
