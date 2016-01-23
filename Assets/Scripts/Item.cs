using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private bool flying, broken;

	// Use this for initialization
	void Start () {
        flying = false;
        broken = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public virtual void OnShot()
    {
        //already shot
        if(!broken) return;
    }

    public virtual void OnPlayerCollision()
    {
        //while flying, too ez otherwise
        if(!flying) return;
    }
}
