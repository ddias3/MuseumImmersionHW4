using UnityEngine;
using System.Collections;

public class proximitySoundNode : MonoBehaviour {

	public GameObject player;
	public float distance;
	public float playerThres = .5f;
	public bool hasBeenVisited = false;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(transform.position, player.transform.position);
		if(distance <= playerThres){
			hasBeenVisited = true;
		}


		if(hasBeenVisited){
			print("IT WORKED!");
		}
	}

}
