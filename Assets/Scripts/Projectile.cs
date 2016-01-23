using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    BoxCollider2D coll;
    float spawnTime;
	// Use this for initialization
	void Start () {
        spawnTime = Time.fixedTime;
        coll = GetComponent<BoxCollider2D>();
        coll.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if((Time.fixedTime - spawnTime) > 0.025f){
            coll.enabled = true;
        }
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        var target = c.gameObject;
        var item = target.GetComponent<Item>();

        if (item != null)
        {
            item.OnShot();
        }

        Destroy(this.gameObject);
    }
}
