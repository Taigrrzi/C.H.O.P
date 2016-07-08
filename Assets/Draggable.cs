using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

    Rigidbody2D myRigidBody;
    Collider2D myCollider;
    public bool selected;
	// Use this for initialization
	void Start () {
        myCollider = gameObject.GetComponent<Collider2D>();
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 mousePoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (Input.GetMouseButtonDown(0)) {
            if (myCollider.OverlapPoint(mousePoint))
            {
                selected = true;
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }

        if (selected)
        {
            myRigidBody.AddForce((mousePoint - new Vector2(transform.position.x, transform.position.y)) * 1000);
        }
	}
}
