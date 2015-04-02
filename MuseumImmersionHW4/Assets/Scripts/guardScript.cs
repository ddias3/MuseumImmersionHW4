using UnityEngine;
using System.Collections;

public class guardScript : MonoBehaviour {

	public float timer = 6f;
	float origTimer = 0f;

	public AudioSource guardVoice;

	public AudioClip farWarn;
	public AudioClip medWarn;
	public AudioClip closeWarn;
	public AudioClip veryCloseWarn;

	public float distance = 0f;

	public GameObject player;

	// Use this for initialization
	void Start () {
		distance = Vector3.Distance(player.transform.position, transform.position);
		origTimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(player.transform.position, transform.position);
		if(timer > 0){
			timer-= Time.deltaTime;
		}
		else{
			if(distance < 20 && distance >= 15){
				guardVoice.clip = medWarn;
				guardVoice.Play();
			}
			if(distance < 15 && distance >= 10){
				guardVoice.clip = farWarn;
				guardVoice.Play();
			}
			if(distance < 10 && distance >= 5){
				guardVoice.clip = closeWarn;
				guardVoice.Play();
			}
			if(distance < 5){
				guardVoice.clip = veryCloseWarn;
				guardVoice.Play();
			}
			timer = origTimer;
		}


	}
}
