using UnityEngine;
using System.Collections;

public class audioTimer : MonoBehaviour {

	public float timer = 65f;
	float origTimer;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		origTimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
		timer-= Time.deltaTime;
		if(timer <=0){
			source.Play();
			timer = origTimer;
		}
	}
}
