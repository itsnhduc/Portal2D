using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {


    public float speed;
    private Rigidbody2D rb;
    float j;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;
        dir = (1 + 100 / dir.magnitude) * dir;
        rb.AddForce(dir * speed);
        j = Vector3.Angle(new Vector3(10, 0, 0), dir);
        if ( dir.y > 0)
        {
            rb.rotation = j;
            Debug.Log("Tuk");
            Debug.Log(j);
        }
        else { rb.rotation=360-j;
            Debug.Log("Tam");
            Debug.Log(dir.z);
            Debug.Log(j);
        }
           
    }
	
	void Update () {
            

    }
}
