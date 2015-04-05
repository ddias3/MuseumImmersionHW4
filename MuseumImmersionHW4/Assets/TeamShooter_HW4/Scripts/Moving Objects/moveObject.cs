using UnityEngine;
using System.Collections;

public class moveObject : MonoBehaviour {


	//These are the points our object will be visiting.
	public GameObject[] movingPoints;

	//This is the object that will be moving. Make your object a child of this object
	public GameObject lerpObject;

	//ID of the thing we're going from
	public int fromID = 0;

	//ID of the thing we're moving to
	public int toID = 1;

	//This is the float the Lerp() requires. It goes from 0 to 1, then resets.
	public float lerpProgress = 0;

	//This is how fast the lerpProgress increments.
	public float lerpSpeed = .01f;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = movingPoints[0].transform.position;
	}

	//This handles all of our Lerp stuff
	void lerpCall(){
		//Our LERP call. Puts us a [lerpProgress]% between fromPoint and toPoint.
		gameObject.transform.position = Vector3.Lerp(movingPoints[fromID].transform.position, movingPoints[toID].transform.position, lerpProgress);
		//Increment our [lerpProgress]% by [lerpSpeed]
		lerpProgress+=lerpSpeed;
		if(lerpProgress>1){
			//If we're done with our lerp, reset all of the variables, increment the From and To IDs.
			lerpProgress = 0;
			fromID++;
			toID++;
			if(fromID == movingPoints.Length){
				fromID = 0;
			}
			if(toID == movingPoints.Length){
				toID = 0;
			}

		}

	}

	// Update is called once per frame
	void Update () {
		lerpCall();
	}
}
