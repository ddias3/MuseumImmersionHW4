﻿using UnityEngine;
using System.Collections;

public class interestedSoundButton : MonoBehaviour {

	public float timer = 1f;
	
	float timerReset;
	
	public bool shouldTimer = false;
	
	public bool shouldPlay = false;
	
	public int arrayInt = 0;
	
	public proximitySoundNode[] nodeArray = new proximitySoundNode[1];
	
	// Use this for initialization
	void Start () {
		timerReset = timer;
		timer = 0;
	}
	
	public void buttonUpdate(){
		if(shouldTimer){
			if(timer > 0){
				timer-= Time.deltaTime;
			}
			else{
				timer = timerReset;
				shouldPlay = true;
			}
		}
		if(shouldPlay){
			if(arrayInt >= nodeArray.Length){
				shouldPlay = false;
				shouldTimer = false;
				arrayInt = 0;
				timer = 0;
			}
			else{
				if(nodeArray[arrayInt].isVisited() == false){
					nodeArray[arrayInt].playTierSound();
				}
				shouldPlay = false;
				arrayInt++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp (KeyCode.E)){
			shouldTimer = true;
		}
		buttonUpdate();
	}
	
	public void playCheck(){
		for(int i = 0; i < nodeArray.Length; i++){
			if(nodeArray[i].isVisited() == false){
				nodeArray[i].playTierSound();
			}
			float f = 2f;
		}
	}
}
