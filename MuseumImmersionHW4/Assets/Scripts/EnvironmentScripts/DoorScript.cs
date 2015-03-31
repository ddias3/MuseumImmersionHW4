using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
	public float rotateSpeed;
	public float rotateAmount;

	public Transform doorTransform;
	public Collider frontTrigger;
	public Collider backTrigger;

	public int state;

	private float currentDegree;

	void Update()
	{
		switch (state)
		{
		case -1:

			break;
		case 0:
			break;
		case 1:
			break;
		}
	}
}
