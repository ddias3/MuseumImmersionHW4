using UnityEngine;
using System.Collections;

public class PopularityManager : MonoBehaviour
{
	public AudioSource popularitySource;
	public AudioClip[] popularityClips;

	public void TriggerAudioCue(int popularityLevel)
	{
		popularitySource.clip = popularityClips[popularityLevel - 1];
		popularitySource.Play();
	}
}
