using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

public class ViewFrustum : MonoBehaviour
{
	public Transform transform;

	public float sweepingWidth;
	public ViewListener[] viewListeners;

	public int affectingItemsLayerMask;
	public int desiredItemLayer;

	private float angleToSide;
	private ListDictionary viewListenersDictionary;

	void Start()
	{
		angleToSide = sweepingWidth * 0.5f;
		viewListenersDictionary = new ListDictionary();
		for (int n = 0; n < viewListeners.Length; ++n)
			viewListenersDictionary.Add(viewListeners[n].gameObject.GetInstanceID(), new ViewListenerInfo(viewListeners[n]));
	}

	void Update()
	{
		foreach (DictionaryEntry entry in viewListenersDictionary)
			((ViewListenerInfo)(entry.Value)).ClearCurrentLooking();

		RaycastHit rayHitMid = new RaycastHit();

		if (Physics.Raycast(transform.position,
		                    transform.forward,
		                    out rayHitMid,
		                    Mathf.Infinity,
		                    affectingItemsLayerMask))
		{
			if (rayHitMid.collider.gameObject.layer == desiredItemLayer)
			{
				ViewListenerInfo viewListenerInfo = viewListenersDictionary[rayHitMid.collider.gameObject.GetInstanceID()] as ViewListenerInfo;
				if (viewListenerInfo.viewListener.GetMaximumDistance() >= rayHitMid.distance)
					viewListenerInfo.currentLooking = true;
			}
		}

//		if (Input.GetKeyDown(KeyCode.T))
//		{
//			RaycastHit rayHitTest = new RaycastHit();
//			
//			bool testHit = Physics.Raycast(transform.position,
//						                    transform.forward,
//						                    out rayHitTest,
//						                    Mathf.Infinity,
//						                    affectingItemsLayerMask);
//
//			Debug.Log("Hit = " + testHit + ", " + transform.position + " -> " + transform.forward + " hit object "
//			          + ((testHit) ? rayHitTest.collider.gameObject.name : "<NOTHING>") + " at distance " + rayHitTest.distance);
//		}
		
		foreach (DictionaryEntry entry in viewListenersDictionary)
		{
			ViewListenerInfo info = ((ViewListenerInfo)(entry.Value));
			if (info.currentLooking)
			{
				info.viewListener.OnView(rayHitMid.distance);
			}

			if (!info.previousLooking && info.currentLooking)
			{
				info.viewListener.OnViewEnter(rayHitMid.distance);
//				Debug.Log(info.viewListener.gameObject.GetInstanceID() + " hit OnViewEnter");
			}
			else if (info.previousLooking && !info.currentLooking)
			{
				info.viewListener.OnViewExit(rayHitMid.distance);
//				Debug.Log(info.viewListener.gameObject.GetInstanceID() + " hit OnViewExit");
			}
		}

		foreach (DictionaryEntry entry in viewListenersDictionary)
			((ViewListenerInfo)(entry.Value)).SetPreviousToCurrent();
	}

	private sealed class ViewListenerInfo
	{
		public bool currentLooking;
		public bool previousLooking;
		public ViewListener viewListener;

		public ViewListenerInfo(ViewListener viewListener)
		{
			currentLooking = false;
			previousLooking = false;
			this.viewListener = viewListener;
		}

		public void SetPreviousToCurrent()
		{
			previousLooking = currentLooking;
		}

		public void ClearCurrentLooking()
		{
			currentLooking = false;
		}
	}
}
