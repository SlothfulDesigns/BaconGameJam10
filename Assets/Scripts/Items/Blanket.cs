using UnityEngine;
using System.Collections;

public class Blanket : Item {

	// Update is called once per frame
	void Update () {
	

	}

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.name == "Player")
        {
            return;
        }
    }

    public override void OnShot(){
        base.OnShot();

        var level = FindObjectOfType<Level1>();
        if (level != null)
        {
            level.CompleteObjective("leaveBed");
            level.FreePlayer();
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, -500.0f));
    }
}
