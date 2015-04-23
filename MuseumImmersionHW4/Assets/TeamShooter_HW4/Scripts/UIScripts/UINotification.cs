using UnityEngine;
using UnityEngine.UI;

public class UINotification : MonoBehaviour
{
	public int type;
	public Text typeText;
	public Text infoText;

	public Image arrow;
	public float arrowRotation;

	public RectTransform background;
	public Image backgroundImage;

	public float yPosition = 0.0f;

	public void SaveYPosition()
	{
		yPosition = transform.position.y;
	}
}

