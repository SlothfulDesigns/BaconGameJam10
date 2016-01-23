using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Vector2 movement;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
	}

    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void HandleMovement(){
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        movement = new Vector2(h * moveSpeed, v * moveSpeed);
    }
}
