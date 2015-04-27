using UnityEngine;
using System.Collections;

public class BGMScript : MonoBehaviour {
	public AudioSource BGMplayer;
	public GameObject playerObj;
	public AudioClip[] clips;
	Vector3 position;
	bool enableBGM;
	// Use this for initialization
	void Start () {
		//BGMplayer = GameObject.Find("BGMplayer").GetComponent<AudioSource>();
		position = playerObj.transform.position;
		BGMplayer.clip = clips[3];
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
				if(!BGMplayer.clip.Equals(clips[0])){
					BGMplayer.Stop();
					BGMplayer.clip = clips[0];
				}
			}else if (position.x >= 30 && position.z >=25){
				if(!BGMplayer.clip.Equals(clips[1])){
					BGMplayer.Stop();
					BGMplayer.clip = clips[1];
				}
			}else if (position.x >= 20 && position.z <=25){
				if(!BGMplayer.clip.Equals(clips[2])){
					BGMplayer.Stop();
					BGMplayer.clip = clips[2];
				}
			}else{
				BGMplayer.Stop();
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
