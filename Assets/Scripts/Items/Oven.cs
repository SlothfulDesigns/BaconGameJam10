using UnityEngine;
using System.Collections;

public class Oven : Item {

    private bool hasBacon, heated;
    private float cookingTime;

    private AudioSource audioSource;
    private AudioClip baconpancakes;
    private bool pancaked;

    private Level1 level;

	// Use this for initialization
	void Start () {
        pancaked = false;
        audioSource = GetComponent<AudioSource>();
        baconpancakes = Resources.Load<AudioClip>("Sounds/pekoni");
        cookingTime = 0.0f;
        level = FindObjectOfType<Level1>();
	}
	
	// Update is called once per frame
	void Update () {

        hasBacon = GetComponentInChildren<Bacon>() != null;

        if (heated && hasBacon)
        {
            cookingTime += Time.fixedDeltaTime;

            if (!pancaked)
            {
                audioSource.PlayOneShot(baconpancakes);
                pancaked = true;
            }
        }

        if (cookingTime > 5.0f)
        {
            level.CompleteObjective("fryBacon");
        }
	
	}

    public override void OnShot(){
        base.OnShot();
        if (base.IsBroken())
        {
            heated = true;
            level.CompleteObjective("heatOven");
        }
    }
}
