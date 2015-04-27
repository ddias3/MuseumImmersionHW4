using UnityEngine;
using System.Collections;

public class TourNoticeTimer : MonoBehaviour {
	int timer;
	AudioSource tourNotice;
	public AudioClip farOffNotice;
	public AudioClip tourImminent;
	float distance;
	// Use this for initialization
	void Start () {
		timer = 7000;
		tourNotice = GameObject.Find("Tour Notice").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timer --;

		if(timer == 300){
			TourImminent();
		}else if(timer == 1000){
			TourIn3();
		}else if(timer == 3000){
			TourIn5();
		}else if(timer == 6000){
			TourIn10();
		}

		if(timer <= 0){
			timer = 6000;
		}
	}
	void TourIn10(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = .75f;
		tourNotice.volume = 1;
		tourNotice.Play();
	}
	void TourIn5(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = .85f;
		tourNotice.volume = 1;
		tourNotice.Play();
	}
	void TourIn3(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = 1f;
		tourNotice.volume = 1;
		tourNotice.Play();
	}
	void TourImminent(){
		tourNotice.clip = tourImminent;
		tourNotice.pitch = 1f;
		tourNotice.volume = .8f;
		tourNotice.time = 2;
		tourNotice.Play();
	}
}
