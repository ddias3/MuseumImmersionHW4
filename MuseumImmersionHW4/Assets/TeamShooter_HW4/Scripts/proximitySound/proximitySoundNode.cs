using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class proximitySoundNode : MonoBehaviour {

	public GameObject player;
	public float distance;
	public float playerThres = 4f;
	public bool hasBeenVisited = false;

	public int soundTier = 1;

	public int distTier1 = 25;

	public int distTier2 = 50;

	public int distTier3 = 75;


	public AudioSource tier0Sound;
	public AudioSource tier1Sound;
	public AudioSource tier2Sound;
	public AudioSource tier3Sound;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
		}
		distance = Vector3.Distance(transform.position, player.transform.position);
		if(distance <= playerThres){
			hasBeenVisited = true;
		}
		else{
			if(distance < distTier1){
				soundTier = 1;
			}
			if(distance > distTier1 && distance < distTier2){
				soundTier = 2;
			}
			if(distance > distTier2 && distance < distTier3){
				soundTier = 3;
			}
			if(distance > distTier3){
				soundTier = 4;
			}
		}
	}

	public bool isVisited(){
		return hasBeenVisited;
	}

	public int getDistTier(){
		return soundTier;
	}

	public void playTierSound(){
		if(hasBeenVisited == false){
			if(soundTier == 1){
				tier0Sound.Play ();
			}
			else if(soundTier == 2){
				tier1Sound.Play ();
			}
			else if(soundTier == 3){
				tier2Sound.Play ();
			}
			else if(soundTier == 4){
				tier3Sound.Play ();
			}
		}
	}

}
