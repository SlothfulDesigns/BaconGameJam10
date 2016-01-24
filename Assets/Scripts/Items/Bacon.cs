using UnityEngine;
using System.Collections;

public class Bacon : MonoBehaviour {

    Level1 level;

    private bool got, put;

	// Use this for initialization
	void Start () {
        level = FindObjectOfType<Level1>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other){
        if (!got && other.name == "Player")
        {
            transform.SetParent(other.transform);
            level.CompleteObjective("getBacon");
            got = true;
        }
        if (!put && other.name == "Oven")
        {
            transform.SetParent(other.transform);
            Vector3 parentPos = other.transform.position;
            //parentPos.x += 0.008f;
            parentPos.y += 0.10f;
            transform.position = parentPos;
            level.CompleteObjective("putBaconOnOven");
            put = true;
        }
    }
}
