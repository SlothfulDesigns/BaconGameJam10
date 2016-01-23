using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Vector2 movement, aimDirection, position, mousePosition;
    private bool aiming;

	// Use this for initialization
	void Start () {
        position = new Vector2(transform.position.x, transform.position.y);
        mousePosition = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {

        position.Set(transform.position.x, transform.position.y);
        mousePosition.Set(Input.mousePosition.x, Input.mousePosition.y);
        aimDirection = (mousePosition - position).normalized;

        HandleMovement();
        if (Input.GetButton("Fire"))
            StartCoroutine(Aim());
	}

    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void HandleMovement()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        movement = new Vector2(h, v) * moveSpeed;
    }

    private void Shoot()
    {
    }

    IEnumerator Aim()
    {
        while (Input.GetButton("Fire"))
        {
            aiming = true;
            var raycast = Physics2D.Raycast(position, Camera.main.ScreenToWorldPoint(mousePosition));
            if (raycast.collider != null)
            {
                var hit = raycast.point;

                Debug.DrawLine(transform.position, new Vector3(hit.x, hit.y, 0.0f), Color.red);

                yield return null;
            }
        }
        aiming = false;
    }
}
