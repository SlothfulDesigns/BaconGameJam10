using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestMenu : MonoBehaviour {

    Level level;
    QuestMenu menu;

	// Use this for initialization
	void Start () {
        level = FindObjectOfType<Level>();

	}
	
	// Update is called once per frame
	void Update () {
        var items = GetComponent<Text>();
        var quests = level.quests;
        var list = "";

        foreach (var q in quests)
        {
            var completed = " ";

            if (q.IsCompleted())
                completed = "X";

            list += "\n[" + completed + "] " + q.name;
        }
        items.text = list;
	}
}
