using UnityEngine;
using System.Collections;

public class Car : Item{

    public enum Doors{
        CLOSED = 0,
        OPEN = 1,
        GETIN = 2,
    };

    public Doors open;

	// Use this for initialization
	void Start () {
        open = Doors.CLOSED;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnShot()
    {
        //already shot
        if (GetComponent<Animator>() != null)
        {
            if (open == Doors.CLOSED)
            {
                Debug.Log("open");
                GetComponent<Animator>().SetInteger("status", 1);
                open = Doors.OPEN;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){

        if (other.name != "Player")
            return;

        if (open == Doors.OPEN)
        {
            open = Doors.GETIN;

            GetComponent<Animator>().SetInteger("status", 2);
            var player = GameObject.Find("Player");
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Player>().SetControllable(false);

            FindObjectOfType<Level1>().CompleteObjective("getInCar");
        }
    }
}
