using UnityEngine;
using System.Collections;

public class AlarmClock : Item {

    private float lastBeep;
    public bool ringing;
	// Use this for initialization
	void Start () {
        base.Start();
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
            if (base.GetComponent<Animator>() != null)
            {
                base.GetComponent<Animator>().SetBool("ringing", ringing);
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
