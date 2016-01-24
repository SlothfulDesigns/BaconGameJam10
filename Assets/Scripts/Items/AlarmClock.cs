using UnityEngine;
using System.Collections;

public class AlarmClock : Item {

    public bool ringing;
	
	// Update is called once per frame
	void Update () {
        if (!IsBroken())
        {
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
