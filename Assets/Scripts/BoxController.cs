using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    public static bool grabbed;
    public static RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdPoint;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            if (!grabbed) {
                Physics2D.queriesStartInColliders = false;            
                if (hit.collider != null && hit.transform.tag=="Crate") {
                    grabbed = true;
                }
            }
            else
            {
                grabbed = false;

                //if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
                  //  hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1);
                //}
            }
        }
        if (grabbed) {
            hit.collider.gameObject.transform.position=holdPoint.position;
        }

    }
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);

    }
}

