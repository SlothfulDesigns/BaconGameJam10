using UnityEngine;
using System.Collections;

public class AlarmClock : Item {

    private float lastBeep;
	// Use this for initialization
	void Start () {
        lastBeep = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsBroken())
        {
            if((Time.fixedTime - lastBeep) > 1.0){
                Debug.Log("beep beep");
                lastBeep = Time.fixedTime;
            }
        }
	}

    public override void OnShot()
    {
        base.OnShot();

        var level = FindObjectOfType<Level1>();
        if (level != null)
        {
            level.CompleteObjective("shootAlarm");
        }
    }
}
