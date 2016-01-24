using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1 : Level {

    Player player;

	// Use this for initialization
	void Start () {

        var q0 = new Quest("bed", "Wakey wakey eggs and bakey. Rise and shine!", true);
        q0.AddObjective(new Objective("leaveBed"));
        quests.Add(q0);

        var q1 = new Quest("wakeup", "Clock is ringing, you should do something about that", true);
        q1.AddObjective(new Objective("shootAlarm"));
        quests.Add(q1);

        var q2 = new Quest("shower", "Shower without your dad", false);
        q2.AddObjective(new Objective("shower"));
        quests.Add(q2);

        var q4 = new Quest("bacon", "Bakin' bacon pancakes", false);
        q4.AddObjective(new Objective("shootFridge"));
        q4.AddObjective(new Objective("getBacon"));
        q4.AddObjective(new Objective("putBaconOnOven"));
        q4.AddObjective(new Objective("heatOven"));
        q4.AddObjective(new Objective("fryBacon"));
        quests.Add(q4);

        var q5 = new Quest("car", "Get to work", false);
        q5.completesLevel = true;
        q5.AddObjective(new Objective("getInCar"));
        quests.Add(q5);

        player = FindObjectOfType<Player>();
        TrapPlayer();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void TrapPlayer(){
        player.GetComponent<Player>().SetControllable(false);
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void FreePlayer(){
        player.GetComponent<Player>().SetControllable(true);
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
    }

}

