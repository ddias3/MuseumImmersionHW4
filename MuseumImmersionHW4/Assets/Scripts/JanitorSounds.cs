using UnityEngine;
using System.Collections;

public class JanitorSounds : MonoBehaviour {

	int timer;
	AudioSource janitorSource;
	public AudioClip[] janitorClips;
	int track;
	// Use this for initialization
	void Start () {
		timer = 0;
		track = 0;
		janitorSource = GameObject.Find("Janitor").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer%20 == 0){
			janitorSource.clip = janitorClips[track];
			janitorSource.Play();
			track++;
		}
		timer ++;
		if(timer >= 80){
			timer = 0;
			track = 0;
		}
	}
}
