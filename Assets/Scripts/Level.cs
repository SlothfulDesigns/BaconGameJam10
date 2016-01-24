using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    private bool levelCompleted = false;
    public IList<Quest> quests = new List<Quest>();
    private int numQuests, completedQuests;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        numQuests = quests.Count;
        if (!levelCompleted && completedQuests == numQuests)
        {
            CompleteLevel();
        }
	}

    void Update(){
    }

    public bool IsQuestComplete(string id)
    {
        foreach (var q in quests)
        {
            if (q.name != "bed")
                continue;

            return q.IsCompleted();
        }
        return false;
    }

    public void CompleteObjective(string id)
    {
        foreach (var q in quests)
        {
            if (!q.HasObjective(id)) continue;

            if (q.CompleteObjective(id))
            {
                if (q.IsCompleted())
                {
                    completedQuests++;
                    if (q.completesLevel)
                    {
                        CompleteLevel();
                    }
                }
            };
        }
    }

    public void CompleteLevel()
    {
        if (!levelCompleted)
        {
            levelCompleted = true;
            Debug.Log("Level complete!");
        }
    }
}
