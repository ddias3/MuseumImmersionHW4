using UnityEngine;
using System.Collections;

public class MueseumClosingScript : MonoBehaviour {
	AudioSource closingAlert;
	public AudioClip alertSoundEffect;
	UIManager UImanager;
	// Use this for initialization
	void Start () {
		closingAlert= GameObject.Find("MuseumClosingSource").GetComponent<AudioSource>();
		closingAlert.clip = alertSoundEffect;
		UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.V)){
			closingAlert.Play();
			UImanager.AddNotification(Color.red, "Museum is Clsoing", "The Museum is now closed! Please exit the building", 5);
		}
	}
}
