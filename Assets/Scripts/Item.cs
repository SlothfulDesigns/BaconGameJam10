using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private bool flying, broken;
    public bool noBrokenRigidbody;
    private Animator mAnimator;
    private Rigidbody2D mRigidbody;

	// Use this for initialization
	public void Start () {
        flying = false;
        broken = false;

        if (GetComponent<Animator>() != null)
        {
            mAnimator = GetComponent<Animator>();
        }

        if (GetComponent<Rigidbody2D>() != null)
        {
            mRigidbody = GetComponent<Rigidbody2D>();
        }
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

        if (mAnimator != null)
        {
            mAnimator.SetBool("broken", true);
        }

        if (HasRigidBody() && noBrokenRigidbody)
        {
            mRigidbody.simulated = false;
        }

        Debug.Log(this.name + " shot to shit");
    }

    public virtual void OnPlayerCollision()
    {
        //while flying, too ez otherwise
        if(!flying) return;
    }

    public bool HasAnimator(){
        return mAnimator != null;
    }

    public Animator GetAnimator(){
        return this.mAnimator;
    }

    public bool HasRigidBody(){
        return mRigidbody != null;
    }

    public Rigidbody2D GetRigidBody(){
        return this.mRigidbody;
    }
}
