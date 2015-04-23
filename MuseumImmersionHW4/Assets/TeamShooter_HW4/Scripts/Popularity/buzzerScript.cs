using UnityEngine;
using System.Collections;

public class buzzerScript : MonoBehaviour {

	public float timer = 6f;
	float origTimer = 0f;
	
	public AudioSource buzzSource;
	

	public AudioClip buzzWarn;

	
	public float distance = 0f;
	
	public GameObject player;

	// Use this for initialization
	void Start () {
		distance = Vector3.Distance(player.transform.position, transform.position);
		origTimer = timer;

		//player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(player.transform.position, transform.position);
		if(timer > 0){
			timer-= Time.deltaTime;
		}
		else{
			if(distance < 10){
				buzzSource.clip = buzzWarn;
				buzzSource.Play();
				timer = origTimer;
			}
		}
	}
}
