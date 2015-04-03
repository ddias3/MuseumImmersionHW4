using UnityEngine;
using System.Collections;

public class PlayerFootstep : MonoBehaviour {
	int pedometer;
	int track;
	public AudioClip footstep1;
	public AudioClip footstep2;
	public AudioClip footstep3;
	public AudioClip footstep4;
	AudioClip[] clips;

	AudioSource footsteps;

	// Use this for initialization
	void Start () {
		track = 0;
		pedometer = 0;
		clips = new AudioClip[4];
		clips[0] = footstep1;
		clips[1] = footstep2;
		clips[2] = footstep3;
		clips[3] = footstep4;

		footsteps = GameObject.Find("Player Footsteps").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w")||Input.GetKey("s")||Input.GetKey("a")||Input.GetKey("d")){
			pedometer++;
			if(pedometer%30==0){
				track = Random.Range(0,3);
				if(pedometer%180 == 0){
					pedometer = 0;
				}
				footsteps.clip = clips[track];
				footsteps.Play();
			}
		}
	}
}
