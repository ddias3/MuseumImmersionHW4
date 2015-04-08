using UnityEngine;
using System.Collections;

public class TourNoticeTimer : MonoBehaviour {
	int timer;
	AudioSource tourNotice;
	public AudioClip farOffNotice;
	public AudioClip tourImminent;
	// Use this for initialization
	void Start () {
		timer = 1500;
		tourNotice = GameObject.Find("Tour Notice").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timer --;

		if(timer == 300){
			TourImminent();
		}else if(timer == 550){
			TourIn3();
		}else if(timer == 800){
			TourIn5();
		}else if(timer == 1050){
			TourIn10();
		}

		if(timer <= 0){
			timer = 1500;
		}
	}

	void TourIn10(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = .75f;
		tourNotice.volume = .8f;
		tourNotice.Play();
	}
	void TourIn5(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = .85f;
		tourNotice.volume = .9f;
		tourNotice.Play();
	}
	void TourIn3(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = 1f;
		tourNotice.volume = 1f;
		tourNotice.Play();
	}
	void TourImminent(){
		tourNotice.clip = tourImminent;
		tourNotice.pitch = 1f;
		tourNotice.volume = 1f;
		tourNotice.time = 2f;
		tourNotice.Play();
	}
}
