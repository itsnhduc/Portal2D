using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {


    public float speed;
    private Rigidbody2D rb;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            rb.AddForce(dir * speed);

    }
}
