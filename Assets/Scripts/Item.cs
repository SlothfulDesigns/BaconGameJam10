using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private bool flying, broken;
    public bool noBrokenRigidbody;

    private AudioClip breakFx;
    private AudioSource audioSource;

	// Use this for initialization
	public void Start () {
        audioSource = this.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            breakFx = Resources.Load<AudioClip>("Sounds/break");
        }
        flying = false;
        broken = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public bool IsBroken(){
        return broken;
    }

    public virtual void OnShot()
    {
        //already shot
        if(broken) return;
        broken = true;

        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetBool("broken", true);
        }

        if (GetComponent<Rigidbody2D>() != null  && noBrokenRigidbody)
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        if (audioSource != null)
        {
            audioSource.PlayOneShot(breakFx);
        }
    }

    public virtual void OnPlayerCollision()
    {
        //while flying, too ez otherwise
        if(!flying) return;
    }
}
