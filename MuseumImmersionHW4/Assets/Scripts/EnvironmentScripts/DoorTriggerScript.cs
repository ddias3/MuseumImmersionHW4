using UnityEngine;
using System.Collections;

public class DoorTriggerScript : MonoBehaviour
{
	public int toState;
	public DoorScript door;

	void OnTriggerEnter(Collider other)
	{
		if (toState == 1)
			door.SetFrontActive(true);
		else
			door.SetBackActive(true);
	}

	void OnTriggerExit(Collider other)
	{
		if (toState == 1)
			door.SetFrontActive(false);
		else
			door.SetBackActive(false);
	}
}

