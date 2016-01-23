using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Vector2 movement, position, mousePosition, aimDirection;
    private bool aiming, weaponReady;

    public GameObject bullet;

	// Use this for initialization
	void Start () {
        bullet = Resources.Load("Bullet") as GameObject;
        position = new Vector2(transform.position.x, transform.position.y);
        mousePosition = new Vector2();
        weaponReady = true;
	}
	
	// Update is called once per frame
	void Update () {

        position.Set(transform.position.x, transform.position.y);

        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.Set(mouse.x, mouse.y);
        aimDirection = (mousePosition - position).normalized;

        HandleMovement();

        if (Input.GetButton("Aim"))
            StartCoroutine(Aim());

        if (Input.GetButton("Fire") && weaponReady)
        {
            Shoot();
            if (aiming) weaponReady = false;
        }

        if (Input.GetButtonUp("Fire") && !weaponReady)
        {
            weaponReady = true;
        }
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
            weaponReady = !aiming;

            GameObject projectile = Instantiate(bullet) as GameObject;
            projectile.transform.position = position;
            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.simulated = true;

            rb.AddForce(aimDirection * 2000);

            if (!aiming)
            {
                var scatter = Mathf.Sin(Time.frameCount / 2) * GetRandom();
                rb.AddForce(new Vector2(scatter, scatter) * 500);
            }
    }

    private static float GetRandom(){
        return Random.Range(0.1f, 1.0f);
    }

    IEnumerator Aim()
    {
        while (Input.GetButton("Aim"))
        {
            aiming = true;
            var raycast = Physics2D.Raycast(position, aimDirection);
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
