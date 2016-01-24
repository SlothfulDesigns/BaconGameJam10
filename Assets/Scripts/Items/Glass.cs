using UnityEngine;
using System.Collections;

public class Glass : Item {

	// Use this for initialization
	void Start () {
        base.SetBreakFx("Sounds/glassbreaks");
	}
}
