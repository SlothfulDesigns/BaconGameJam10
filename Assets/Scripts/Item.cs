using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    bool flying, broken;
    Animator animator;

	// Use this for initialization
	void Start () {
        flying = false;
        broken = false;
        animator = GetComponent<Animator>();
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

        if (animator != null)
        {
            animator.SetBool("broken", true);
        }

        Debug.Log(this.name + " shot to shit");
    }

    public virtual void OnPlayerCollision()
    {
        //while flying, too ez otherwise
        if(!flying) return;
    }
}
