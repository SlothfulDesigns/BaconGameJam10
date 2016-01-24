using UnityEngine;
using System.Collections;

public class AlarmClock : Item {

    public bool ringing;
    private float lastRing;
    private AudioSource audioSource;
    private AudioClip alarmFx;

    void Start(){
        lastRing = Time.fixedTime;
        audioSource = GetComponent<AudioSource>();
        alarmFx = Resources.Load<AudioClip>("Sounds/alarm");
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsBroken())
        {
            if (base.GetComponent<Animator>() != null)
            {
                base.GetComponent<Animator>().SetBool("ringing", ringing);
            }
            if (ringing)
            {
                if (Time.fixedTime - lastRing > 1.0f)
                {
                    audioSource.PlayOneShot(alarmFx);
                    lastRing = Time.fixedTime;
                }
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
