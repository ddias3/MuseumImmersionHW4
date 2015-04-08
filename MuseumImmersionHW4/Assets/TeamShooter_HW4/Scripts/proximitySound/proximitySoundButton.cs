using UnityEngine;
using System.Collections;

public class proximitySoundButton : MonoBehaviour {


	public float timer = 1f;

	public bool shouldTimer = false;

	public bool shouldPlay = false;

	public int arrayInt = 0;

	public proximitySoundNode[] nodeArray = new proximitySoundNode[1];

	// Use this for initialization
	void Start () {

	}

	public void buttonUpdate(){
		if(shouldTimer){
			if(timer > 0){
				timer-= Time.deltaTime;
			}
			else{
				timer = 1f;
				shouldPlay = true;
			}
		}
		if(shouldPlay){
			if(arrayInt >= nodeArray.Length){
				shouldPlay = false;
				shouldTimer = false;
				arrayInt = 0;
			}
			else{
				nodeArray[arrayInt].playTierSound();
				shouldPlay = false;
				arrayInt++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp (KeyCode.Q)){
			shouldTimer = true;
		}
		buttonUpdate();
	}

	public void playCheck(){
		for(int i = 0; i < nodeArray.Length; i++){
			if(!(nodeArray[i].isVisited())){
				nodeArray[i].playTierSound();
			}
			float f = 2f;
		}
	}

}
