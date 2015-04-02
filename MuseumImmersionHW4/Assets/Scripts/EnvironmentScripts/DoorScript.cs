using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
	public float rotateSpeed;
	public float rotateAmount;

	private float interpDelta;

	public Transform doorTransform;
	private Quaternion originalRotation;
	public Collider frontTrigger;
	public Collider backTrigger;

	public int state;
	
	public AnimationCurve easeFunction;

	private float currentDegreeInterp = 0;

	private bool triggerFrontTriggered;
	private bool triggerBackTriggered;

	public AudioSource doorSource;
	public AudioClip doorOpen;
	public AudioClip doorClose;

	private bool playSound = false;

	void Start()
	{
		originalRotation = doorTransform.localRotation;
		interpDelta = rotateAmount / rotateSpeed;
	}

	void Update()
	{
		switch (state)
		{
		case -1:
			if (currentDegreeInterp > -1)
			{
				currentDegreeInterp -= interpDelta * Time.deltaTime;

				if (currentDegreeInterp < -1)
					currentDegreeInterp = -1;
			}
			break;
		case 0:
			if (Mathf.Abs(currentDegreeInterp) < 0.005f)
			{
				currentDegreeInterp = 0.0f;

				if (playSound)
				{
					doorSource.clip = doorClose;
					doorSource.Play();
					playSound = false;
				}
			}
			else if (currentDegreeInterp < 0)
			{
				currentDegreeInterp += interpDelta * Time.deltaTime;
			}
			else if (currentDegreeInterp > 0)
			{
				currentDegreeInterp -= interpDelta * Time.deltaTime;
			}
			break;
		case 1:
			if(currentDegreeInterp == 0){
				doorSource.clip = doorOpen;
				doorSource.Play ();
			}
			if (currentDegreeInterp < 1)
			{
				currentDegreeInterp += interpDelta * Time.deltaTime;
				
				if (currentDegreeInterp > 1)
					currentDegreeInterp = 1;
			}
			break;
		}

		float filteredDegreeInterp;
		if (currentDegreeInterp < 0)
			filteredDegreeInterp = -easeFunction.Evaluate(-currentDegreeInterp);
		else
			filteredDegreeInterp = easeFunction.Evaluate(currentDegreeInterp);

		doorTransform.localRotation = originalRotation * Quaternion.Euler(0, 0, rotateAmount * filteredDegreeInterp);
	}

	public void SetFrontActive(bool front)
	{
		triggerFrontTriggered = front;

		DetermineState();
	}

	public void SetBackActive(bool back)
	{
		triggerBackTriggered = back;

		DetermineState();
	}

	private void DetermineState()
	{
		if (!triggerBackTriggered && !triggerFrontTriggered)
		{
			state = 0;
			playSound = true;

			doorSource.clip = doorOpen;
			doorSource.Play ();
		}
		else if (triggerBackTriggered && !triggerFrontTriggered && state == 0)
		{
			state = -1;

			doorSource.clip = doorOpen;
			doorSource.Play ();
		}
		else if (!triggerBackTriggered && triggerFrontTriggered && state == 0)
		{
			state = 1;

			doorSource.clip = doorOpen;
			doorSource.Play ();
		}
	}
}
