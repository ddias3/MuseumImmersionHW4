using UnityEngine;
using System.Collections;

public class PopularityItemTrigger : ViewListener
{
	public PopularityManager popularityManager;

	public float cooldown = 20.0f;
	public int popularityLevel = 1;

	public float distanceBeforeTrigger = 10.0f;

	private float timeSinceLastViewed = 99999.0f;

	void Update()
	{
		timeSinceLastViewed += Time.deltaTime;
	}

	public override void OnViewEnter(float distance)
	{
		if (distance < distanceBeforeTrigger && timeSinceLastViewed > cooldown)
		{
			timeSinceLastViewed = 0.0f;
			popularityManager.TriggerAudioCue(popularityLevel);
		}
	}

	public override void OnViewExit(float distance)
	{
		// do nothing
	}

	public override void OnView(float distance)
	{
		// do nothing
	}

	public override float GetMaximumDistance()
	{
		return distanceBeforeTrigger;
	}
}

