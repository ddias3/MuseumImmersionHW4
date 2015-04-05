using UnityEngine;

public class NoclipCamera : MonoBehaviour
{
	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	private float pitch = 0;
	private float faster = 1;
	private bool mouseControl = true;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (mouseControl)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				mouseControl = false;
			}
			else
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				mouseControl = true;
			}
		}
		
		faster = 1;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			faster = 12;
		
		transform.position += transform.rotation * (Input.GetAxis("Vertical") * faster * Vector3.forward);
		
		transform.position += transform.rotation * (-Input.GetAxis("Horizontal") * faster * Vector3.left);
		
		if (mouseControl)
		{
			transform.rotation *= Quaternion.Euler(transform.InverseTransformDirection(0, Input.GetAxis("Mouse X"), 0));
			
			float deltaPitch = -Input.GetAxis("Mouse Y");
			
			if (pitch + deltaPitch > 90)
				pitch = 90;
			else if (pitch + deltaPitch < -90)
				pitch = -90;
			else
				pitch += deltaPitch;
			
			transform.rotation = Quaternion.Euler(pitch, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		}
	}
}