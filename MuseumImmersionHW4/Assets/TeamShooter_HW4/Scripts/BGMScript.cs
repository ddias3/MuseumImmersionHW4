using UnityEngine;
using System.Collections;

public class BGMScript : MonoBehaviour {
	public AudioSource BGMplayer;
	public AudioSource crowdPlayer;
	public GameObject playerObj;
	public AudioClip[] BGMclips;
	public AudioClip[] crowdClips;
	public buzzerScript buzzer;
	bool[] alertFired = {false, false, false};
	bool enableBGM;
	bool enableAlerts;

	Vector3 position;

	public UIManager UImanager;
	// Use this for initialization
	void Start () {
		//BGMplayer = GameObject.Find("BGMplayer").GetComponent<AudioSource>();
		position = playerObj.transform.position;
		BGMplayer.clip = BGMclips[3];
		UImanager.museumText.text = "Metro Museum";
		//Clip 1: Classical
		//Clip 2: Jazz
		//Clip 3: Tribal
		enableBGM = true;
		enableAlerts = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			enableBGM = !enableBGM;
		}
		if(Input.GetKeyDown(KeyCode.N)){
			enableAlerts = !enableAlerts;
		}
		position = playerObj.transform.position;

		//BGM
		if(enableBGM){
			if(position.x <= 28 && position.z >=23){
				if(!BGMplayer.clip.Equals(BGMclips[2])){
					//Tribal
					BGMplayer.Stop();
					BGMplayer.volume = 0.25f;
					BGMplayer.clip = BGMclips[2];
				}
			}else if (position.x >= 30 && position.z >=25){
				if(!BGMplayer.clip.Equals(BGMclips[1])){
					//Jazz
					BGMplayer.Stop();
					BGMplayer.volume = 0.5f;
					BGMplayer.clip = BGMclips[1];
				}
			}else if (position.x >= 20 && position.z <=25){
				if(!BGMplayer.clip.Equals(BGMclips[0])){
					//Classical
					BGMplayer.Stop();
					BGMplayer.volume = 0.25f;
					BGMplayer.clip = BGMclips[0];
				}
			}else{
				BGMplayer.Stop();
			}
			if(!BGMplayer.isPlaying&&(!BGMplayer.clip.Equals(BGMclips[3]))){
				BGMplayer.Play();
			}
		}else{
			if(BGMplayer.isPlaying)
				BGMplayer.Stop();
		}
		//Beginning of crowd alerts

		if(enableAlerts){
			if(position.x <= 28 && position.z >=23){
				if(!alertFired[0]){
					//stupid coding cause reasons
					alertFired[0] = true;
					alertFired[1] = false;
					alertFired[2] = false;

					crowdPlayer.clip = crowdClips[0];
					crowdPlayer.volume = .5f;
					crowdPlayer.Play();
					UImanager.AddNotification(Color.cyan, "WARNING", "A large crowd is in the area", 5);
				}
			}else if (position.x >= 30 && position.z >=25){
				if(!alertFired[1]){

					alertFired[0] = false;
					alertFired[1] = true;
					alertFired[2] = false;

					crowdPlayer.clip = crowdClips[1];
					crowdPlayer.Play();
					crowdPlayer.volume = .2f;
					UImanager.AddNotification(Color.cyan, "WARNING", "A small crowd is in the area", 5);
					
				}
			}else if (position.x >= 20 && position.z <=25){
				if(!alertFired[2]){
		
					alertFired[2] = true;
					alertFired[1] = false;
					alertFired[0] = false;

					crowdPlayer.clip = crowdClips[1];
					crowdPlayer.Play();
					crowdPlayer.volume = .2f;
					UImanager.AddNotification(Color.cyan, "WARNING", "A small crowd is in the area", 5);
				}
			}else{
				crowdPlayer.Stop();			}
		}else{
			for(int i = 0; i < 3; i++){
				alertFired[i] = false;
			}
		}

		//UI modes

		if(position.x <= 28 && position.z >=23){
			UImanager.roomText.text = "Sculpture Room";
		}else if (position.x >= 30 && position.z >=25){
			UImanager.roomText.text = "Photo Room";
		}else if (position.x >= 20 && position.z <=25){
			UImanager.roomText.text = "Painting Room";
		}else{
			UImanager.roomText.text = "Exploration Mode...";
		}


	}


}
