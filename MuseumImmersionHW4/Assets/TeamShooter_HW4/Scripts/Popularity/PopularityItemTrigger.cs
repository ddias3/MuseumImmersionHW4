using UnityEngine;
using System.Collections;

public class PopularityItemTrigger : ViewListener
{
	public PopularityManager popularityManager;
	public UIManager uiManager;

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
			switch (popularityLevel)
			{
			case 1:
				uiManager.AddNotification(new Color(195.0f/255, 1.0f, 1.0f), "Popularity", "This is an incredibly popular exhibit.", 6.0f);
				break;
			case 2:
				uiManager.AddNotification(new Color(195.0f/255, 1.0f, 1.0f), "Popularity", "This is a very popular exhibit.", 6.0f);
				break;
			case 3:
				uiManager.AddNotification(new Color(195.0f/255, 1.0f, 1.0f), "Popularity", "This is a popular exhibit.", 6.0f);
				break;
			case 4:
				uiManager.AddNotification(new Color(195.0f/255, 1.0f, 1.0f), "Popularity", "This is a kind of popular exhibit.", 6.0f);
				break;
			}
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

