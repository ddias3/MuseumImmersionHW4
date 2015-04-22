using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
	public int maxNotifications = 5;

	public GameObject prefabNotificationText;
	public GameObject prefabNotificationArrowText;

	public GameObject canvas;
	public GameObject notificationsTitle;

	public Text museumText;
	public Text roomText;
	public Text exhibitText;

	private int currentNotifications;
	private UINotification[] notificationsOutput;

	private List<NotificationWrapper> notificationsList;

	private int activeNotifications = 0;

	void Start()
	{
		notificationsList = new List<NotificationWrapper>();
		notificationsOutput = new UINotification[maxNotifications];
		for (int n = 0; n < maxNotifications; ++n)
			notificationsOutput[n] = null;

		MuseumText = "MUSEUM!!!!";
		RoomText = "Room 001";
		ExhibitText = "This exhibit is the bestest exhibitionest exhibit ev4r";
	}

	void Update()
	{
		for (int n = notificationsList.Count - 1; n >= 0; --n)
			if (notificationsList[n].timeActive > notificationsList[n].timeDisplayed)
				RemoveNotification(notificationsList[n]);

		foreach (NotificationWrapper notification in notificationsList)
			if (notification.active)
				notification.timeActive += Time.deltaTime;		
	}

	public int AddNotification(string typeText, string infoText, float timeDisplayed)
	{
		NotificationWrapper notification = new NotificationWrapper(timeDisplayed, Instantiate<GameObject>(prefabNotificationText));
		notification.notification.gameObject.SetActive(false);
		notification.notification.transform.SetParent(canvas.transform, false);

		notification.notification.typeText.text = typeText;
		notification.notification.infoText.text = infoText;

		notification.notification.SaveYPosition();

		notificationsList.Add(notification);

		CalculateOutputNotifications();

		return notification.id;
	}

	public int AddNotification(string typeText, string infoText, float timeDisplayed, float arrowRotationDegrees)
	{
		NotificationWrapper notification = new NotificationWrapper(timeDisplayed, Instantiate<GameObject>(prefabNotificationArrowText));
		notification.notification.gameObject.SetActive(false);
		notification.notification.transform.SetParent(canvas.transform, false);

		notification.notification.typeText.text = typeText;
		notification.notification.infoText.text = infoText;
		notification.notification.arrowRotation = arrowRotationDegrees;
		notification.notification.arrow.rectTransform.rotation = Quaternion.Euler(0.0f, 0.0f, arrowRotationDegrees);

		notification.notification.SaveYPosition();

		notificationsList.Add(notification);
		
		CalculateOutputNotifications();
		
		return notification.id;
	}

	public bool RemoveNotification(int notificationId)
	{
		NotificationWrapper removingNotification = null;

		foreach (NotificationWrapper notification in notificationsList)
		{
			if (notification.id == notificationId)
			{
				removingNotification = notification;
				break;
			}
		}

		if (removingNotification != null)
			return RemoveNotification(removingNotification);
		else
			return false;
	}

	private bool RemoveNotification(NotificationWrapper candidateNotification)
	{
		int outputPosition = -1;
		for (int n = 0; n < notificationsOutput.Length; ++n)
			if (notificationsOutput[n] == candidateNotification.notification)
				outputPosition = n;

		bool removedFromLL = notificationsList.Remove(candidateNotification);

		Destroy(candidateNotification.notification.gameObject);

		if (outputPosition >= 0)
			if (removedFromLL)
				CalculateOutputNotifications();
			else
				Debug.LogError("Notification in output array but NOT in linked list");

		return removedFromLL;
	}

	public void ClearAllNotifications()
	{
		for (int n = 0; n < notificationsOutput.Length; ++n)
			notificationsOutput[n] = null;

		notificationsList.Clear();
	}

	private void CalculateOutputNotifications()
	{
		int n = 0;
		foreach (NotificationWrapper notificationWrapper in notificationsList)
		{
			if (n >= maxNotifications)
				break;
			
			notificationsOutput[n] = notificationWrapper.notification;
			notificationWrapper.active = true;
			notificationWrapper.notification.gameObject.SetActive(true);

			++n;
		}

		activeNotifications = n;
		if (activeNotifications == 0)
			notificationsTitle.SetActive(false);
		else
			notificationsTitle.SetActive(true);

		for (; n < maxNotifications; ++n)
			notificationsOutput[n] = null;

		for (int m = 0; m < notificationsOutput.Length; ++m)
		{
			if (null == notificationsOutput[m])
				continue;

			RectTransform rectTransform = notificationsOutput[m].GetComponent<RectTransform>(); //.localPosition(new Vector3(-233.3746f, 118.0f, 0.0f));
			float height = rectTransform.rect.height;

			Transform notificationTransform = notificationsOutput[m].GetComponent<Transform>();
			notificationTransform.position = new Vector3(notificationTransform.position.x,
			                                             notificationsOutput[m].yPosition - m * height,
			                                             notificationTransform.position.z);
		}
	}

	public bool SetArrowAngle(int notificationId, float angle)
	{
		NotificationWrapper notificationWrapper = null;
		for (int n = 0; n < notificationsList.Count; ++n)
		{
			if (notificationsList[n].id == notificationId)
			{
				notificationWrapper = notificationsList[n];
				break;
			}
		}

		if (notificationWrapper != null)
		{
			notificationWrapper.notification.arrowRotation = angle;
			notificationWrapper.notification.arrow.rectTransform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
			return true;
		}
		else
			return false;
	}

	private class NotificationWrapper
	{
		private static int s_idIncrementer = 1;
		public int id;
		public bool active;
		public float timeActive;
		public float timeDisplayed;
		public UINotification notification;
		public NotificationWrapper(float t, GameObject n)
		{
			id = s_idIncrementer++;
			active = false;
			timeActive = 0.0f;
			timeDisplayed = t;
			notification = n.GetComponent<UINotification>();
		}
	}

	public string MuseumText
	{
		get { return museumText.text; }
		set { museumText.text = value; }
	}

	public string RoomText
	{
		get { return roomText.text; }
		set { roomText.text = value; }
	}

	public string ExhibitText
	{
		get { return exhibitText.text; }
		set { exhibitText.text = value; }
	}
}
