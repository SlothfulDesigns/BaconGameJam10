using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private bool flying, broken;
    public bool noBrokenRigidbody;

	// Use this for initialization
	public void Start () {
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

        Debug.Log(this.name + " shot to shit");
    }

    public virtual void OnPlayerCollision()
    {
        //while flying, too ez otherwise
        if(!flying) return;
    }
}
