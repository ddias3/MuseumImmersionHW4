using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{
	private Vector3 doorRightOriginalLocalPosition;
	private Vector3 doorLeftOriginalLocalPosition;

	public Transform doorRight;
	public Transform doorLeft;

	public AudioSource source;

	public AudioClip elevatorOpen;
	public AudioClip elevatorClose;

	private float time;

	public float TIME_BETWEEN_OPENS = 30.0f;
	public float TIME_OPENED = 10.0f;
	public float TIME_MOVING = 4.5f;

	private bool playedOpen = false;
	private bool playedClose = false;

	void Start()
	{
		time = 0.0f;
		playedOpen = false;
		playedClose = false;

		doorRightOriginalLocalPosition = doorRight.localPosition;
		doorLeftOriginalLocalPosition = doorLeft.localPosition;
	}

	void Update()
	{
		if (time > TIME_BETWEEN_OPENS + 2 * TIME_MOVING + TIME_OPENED)
		{
			time = 0.0f;
			playedOpen = false;
			playedClose = false;
		}
		else if (time > TIME_BETWEEN_OPENS + TIME_MOVING + TIME_OPENED)
		{
			if (!playedClose)
			{
				source.clip = elevatorClose;
				source.Play();
				playedClose = true;
			}

			doorRight.localPosition = Vector3.Lerp(doorRightOriginalLocalPosition + new Vector3(0, 0, 2.0f), doorRightOriginalLocalPosition, (time - (TIME_BETWEEN_OPENS + TIME_MOVING + TIME_OPENED)) / TIME_MOVING);
			doorLeft.localPosition = Vector3.Lerp(doorLeftOriginalLocalPosition + new Vector3(0, 0, -2.0f), doorLeftOriginalLocalPosition, (time - (TIME_BETWEEN_OPENS + TIME_MOVING + TIME_OPENED)) / TIME_MOVING);
		}
		else if (time > TIME_BETWEEN_OPENS + TIME_MOVING)
		{

		}
		else if (time > TIME_BETWEEN_OPENS)
		{
			if (!playedOpen)
			{
				source.clip = elevatorOpen;
				source.Play();
				playedOpen = true;
			}

			doorRight.localPosition = Vector3.Lerp(doorRightOriginalLocalPosition, doorRightOriginalLocalPosition + new Vector3(0, 0, 2.0f), (time - TIME_BETWEEN_OPENS) / TIME_MOVING);
			doorLeft.localPosition = Vector3.Lerp(doorLeftOriginalLocalPosition, doorLeftOriginalLocalPosition + new Vector3(0, 0, -2.0f), (time - TIME_BETWEEN_OPENS) / TIME_MOVING);
		}

		time += Time.deltaTime;
	}
}
