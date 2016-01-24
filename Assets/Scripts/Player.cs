using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Vector2 movement, position, mousePosition, aimDirection;
    private bool aiming, weaponReady, outOfBed, controllable;

    public GameObject bullet;

    private Animator animator;
    private SpriteRenderer sprite;

    private AudioSource audioSource;
    private AudioClip shootFx;

    private float lastShot;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        bullet = Resources.Load("Bullet") as GameObject;
        shootFx = Resources.Load<AudioClip>("Sounds/pew");

        position = new Vector2(transform.position.x + 1f, transform.position.y + 1f);
        mousePosition = new Vector2();

        lastShot = Time.fixedTime;
        weaponReady = true;

        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        controllable = true;
        position.Set(transform.position.x, transform.position.y);

        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.Set(mouse.x, mouse.y);
        aimDirection = (mousePosition - position).normalized;

        if(controllable) HandleMovement();

        if (Input.GetButton("Aim"))
            StartCoroutine(Aim());

        if (Input.GetButton("Fire") && weaponReady)
        {
            if (Time.fixedTime - lastShot > 0.05)
            {
                Shoot();
                if (aiming)
                    weaponReady = false;
                lastShot = Time.fixedTime;
            }
        }

        if (Input.GetButtonUp("Fire") && !weaponReady)
        {
            weaponReady = true;
        }

        if(Input.GetButton("QuestLog"))
            StartCoroutine(QuestLog());
	}

    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void HandleMovement()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            animator.SetBool("walking", true);
        } else {
            animator.SetBool("walking", false);
        }

        if (h < 0)
        {
            sprite.flipX = true;
        }
        if(h > 0)
        {
            sprite.flipX = false;
        }

        movement = new Vector2(h, v) * moveSpeed;
    }

    private void Shoot()
    {
        weaponReady = !aiming;

        GameObject projectile = Instantiate(bullet) as GameObject;
        projectile.transform.position = position;
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var rb = projectile.GetComponent<Rigidbody2D>();
        rb.simulated = true;

        rb.AddForce(aimDirection * 500);

        if (aiming)
        {
            GetComponent<Rigidbody2D>().AddForce(-aimDirection * 25);
        }
        else
        {
            //todo: actual sideways force
            var sidewaysForce = new Vector2(GetRandom(), GetRandom());

            rb.AddForce(sidewaysForce * 100);
            GetComponent<Rigidbody2D>().AddForce(-aimDirection * 50);
        }
        audioSource.PlayOneShot(shootFx);
    }

    private static float GetRandom(){
        return Random.Range(-0.1f, 1.0f);
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

    IEnumerator QuestLog(){
        var qmenu = GameObject.Find("QuestMenu");

        while (Input.GetButton("QuestLog")){
            qmenu.GetComponent<Canvas>().enabled = true;
            yield return null;
        }
        qmenu.GetComponent<Canvas>().enabled = false;
    }

    public void SetControllable(bool lol){
        controllable = lol;
    }
}
