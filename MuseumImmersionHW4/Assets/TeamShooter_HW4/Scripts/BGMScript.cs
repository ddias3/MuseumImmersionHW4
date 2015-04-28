using UnityEngine;
using System.Collections;

public class BGMScript : MonoBehaviour {
	public AudioSource BGMplayer;
	public GameObject playerObj;
	public AudioClip[] clips;
	public buzzerScript buzzer;
	bool enableBGM;

	Vector3 position;

	public UIManager UImanager;
	// Use this for initialization
	void Start () {
		//BGMplayer = GameObject.Find("BGMplayer").GetComponent<AudioSource>();
		position = playerObj.transform.position;
		BGMplayer.clip = clips[3];
		UImanager.museumText.text = "Metro Museum";
		//Clip 1: Classical
		//Clip 2: Jazz
		//Clip 3: Tribal
		enableBGM = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			enableBGM = !enableBGM;
		}
		if(enableBGM){
			position = playerObj.transform.position;
			if(position.x <= 28 && position.z >=23){
				if(!BGMplayer.clip.Equals(clips[2])){
					//Tribal
					BGMplayer.Stop();
					BGMplayer.clip = clips[2];
					UImanager.roomText.text = "Sculpture Room";

				}
			}else if (position.x >= 30 && position.z >=25){
				if(!BGMplayer.clip.Equals(clips[1])){
					//Jazz
					BGMplayer.Stop();
					BGMplayer.clip = clips[1];
					UImanager.roomText.text = "Artifact Room";
				}
			}else if (position.x >= 20 && position.z <=25){
				if(!BGMplayer.clip.Equals(clips[0])){
					//Classical
					BGMplayer.Stop();
					BGMplayer.clip = clips[0];
					UImanager.roomText.text = "Picture Room";
				}
			}else{
				BGMplayer.Stop();
				UImanager.roomText.text = "Exploration Mode...";
			}
			if(!BGMplayer.isPlaying&&(!BGMplayer.clip.Equals(clips[3]))){
				BGMplayer.Play();
			}
		}else{
			if(BGMplayer.isPlaying)
				BGMplayer.Stop();
		}
	}


}
