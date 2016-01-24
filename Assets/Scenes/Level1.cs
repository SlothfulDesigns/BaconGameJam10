using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1 : Level {



	// Use this for initialization
	void Start () {

        var q1 = new Quest("wakeup", "Wakey wakey eggs and bakey", true);
        q1.AddObjective(new Objective("shootAlarm"));
        quests.Add(q1);

        var q2 = new Quest("shower", "Shower without your dad", false);
        q2.AddObjective(new Objective("shower"));
        quests.Add(q2);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

}

