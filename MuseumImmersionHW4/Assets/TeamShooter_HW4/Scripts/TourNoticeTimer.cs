using UnityEngine;
using System.Collections;

public class TourNoticeTimer : MonoBehaviour {
	int timer;
	AudioSource tourNotice;
	public AudioClip farOffNotice;
	public AudioClip tourImminent;
	// Use this for initialization
	void Start () {
		timer = 2500;
		tourNotice = GameObject.Find("Tour Notice").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timer --;

		if(timer == 300){
			TourImminent();
		}else if(timer == 800){
			TourIn3();
		}else if(timer == 1300){
			TourIn5();
		}else if(timer == 1800){
			TourIn10();
		}

		if(timer <= 0){
			timer = 2500;
		}
	}

	void TourIn10(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = .75f;
		tourNotice.volume = .2f;
		tourNotice.Play();
	}
	void TourIn5(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = .85f;
		tourNotice.volume = .4f;
		tourNotice.Play();
	}
	void TourIn3(){
		tourNotice.clip = farOffNotice;
		tourNotice.pitch = 1f;
		tourNotice.volume = .6f;
		tourNotice.Play();
	}
	void TourImminent(){
		tourNotice.clip = tourImminent;
		tourNotice.pitch = 1f;
		tourNotice.volume = .8f;
		tourNotice.time = 2f;
		tourNotice.Play();
	}
}
