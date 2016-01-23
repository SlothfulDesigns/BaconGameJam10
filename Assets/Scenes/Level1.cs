using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1 : MonoBehaviour {


    public IList<Quest> quests;

	// Use this for initialization
	void Start () {

        quests = new List<Quest>();

        var q1 = new Quest("wakeup", "Wakey wakey eggs and bakey", true);
        q1.AddObjective(new Objective("shootAlarm"));

        quests.Add(q1);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void CompleteObjective(string id){
        foreach (var q in quests)
        {
            q.CompleteObjective(id);
        }
    }
}

