using UnityEngine;
using System.Collections;

public class FlourescentPitchAdjust : MonoBehaviour
{
	private float pitchRoot = 0.95f;
	public AudioSource source;

	void Update ()
	{
		source.pitch = Mathf.Sin(Time.time * 0.8f) * 0.25f + pitchRoot;
	}
}

