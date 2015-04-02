using UnityEngine;
using System.Collections;

public class collisionNoiseCheck : MonoBehaviour {

	public bool allowed = true;
	public float timer = .5f;
	float orig;

	public AudioSource mySource;

	public AudioClip wallClip;	
	public AudioClip canClip;

	// Use this for initialization
	void Start () {
		orig = timer;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0){
			allowed = false;
			timer-= Time.deltaTime;
		}
		else{
			allowed = true;
		}
	}

	void OnCollisionEnter(Collision other){
		if(allowed){
			if(other.gameObject.tag == "Wall"){
				mySource.clip = wallClip;
				mySource.Play();
				print("WALL COLLISION");
			}
			if(other.gameObject.tag == "Can"){
				mySource.clip = canClip;
				mySource.Play();
				print("CAN COLLISION");
			}
			allowed = false;
			timer = orig;
		}
	}

	/*
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Wall"){
			mySource.clip = wallClip;
			mySource.Play();
			print("WALL COLLISION");
		}

		if(other.gameObject.tag == "Can"){
			mySource.clip = canClip;
			mySource.Play();
			print("CAN COLLISION");
		}
	}
	*/
}
