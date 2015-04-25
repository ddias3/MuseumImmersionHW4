using UnityEngine;
using System.Collections;

public class MueseumClosingScript : MonoBehaviour {
	AudioSource closingAlert;
	public AudioClip alertSoundEffect;
	// Use this for initialization
	void Start () {
		closingAlert= GameObject.Find("MuseumClosingSource").GetComponent<AudioSource>();
		closingAlert.clip = alertSoundEffect;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.V)){
			closingAlert.Play();
		}
	}
}
