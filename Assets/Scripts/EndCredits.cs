using UnityEngine;
using System.Collections;

public class EndCredits : MonoBehaviour {

	public GameObject Camera;
	public int speed = 1;
	public string level;

	// Update is called once per frame
	void Update ()
	{
		Camera.transform.Translate(Vector2.down * Time.deltaTime * speed);
	}

	IEnumerator waitFor()
	{
		yield return new WaitForSeconds (20);
		Application.LoadLevel (level);
	}
}