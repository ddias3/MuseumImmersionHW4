using UnityEngine;
using System.Collections;

public class CameramanTiming : MonoBehaviour {
	int timer;
	AudioSource cameraClick;
	// Use this for initialization
	void Start () {
		timer = 0;
		cameraClick = GameObject.Find("Cameraman").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer%90 == 0){
			cameraClick.Play();
		}
		timer ++;
		if(timer >= 180) timer = 0;
	}
}
