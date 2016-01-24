using UnityEngine;
using System.Collections;

public class Shower : Item {

    private bool showering, showered;
    private float showeringTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (showering)
        {
            showeringTime += Time.fixedDeltaTime;
        }

        if (showeringTime > 5) showered = true;

        if(showered)
        {
            var level = FindObjectOfType<Level1>();
            if (level != null)
            {
                level.CompleteObjective("shower");
            }
        }
	}

    void OnTriggerStay2D(Collider2D other){
        if (other.name == "Player" && IsBroken())
        {
            showering = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.name == "Player" && IsBroken())
        {
            showeringTime = 0;
            showering = false;
        }
    }
}
