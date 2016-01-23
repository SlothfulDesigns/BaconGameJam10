using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
