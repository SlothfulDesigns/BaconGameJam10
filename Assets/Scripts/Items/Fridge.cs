using UnityEngine;
using System.Collections;

public class Fridge : Item {

    public bool gaveBacon;
    private Level1 level;
	// Use this for initialization
	new void Start () {
        level = FindObjectOfType<Level1>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnShot(){
        base.OnShot();
        if (!gaveBacon)
        {
            level.CompleteObjective("shootFridge");
            SpawnBacon();
            gaveBacon = true;
        }
    }

    private void SpawnBacon(){
        var obj = Resources.Load("Bacon") as GameObject;
        var pos = this.GetComponent<Transform>().position;
        var bacon = Instantiate(obj);
        var offset = new Vector3(pos.x + 0.1f, pos.y - 0.3f, pos.z);
        bacon.transform.position = offset; 
    }
}
