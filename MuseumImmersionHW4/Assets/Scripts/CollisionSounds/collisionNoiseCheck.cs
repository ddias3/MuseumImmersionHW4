using UnityEngine;
using System.Collections;

public class collisionNoiseCheck : MonoBehaviour {

	public AudioSource mySource;

	public AudioClip wallClip;	
	public AudioClip canClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
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
