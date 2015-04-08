using UnityEngine;

public abstract class ViewListener : MonoBehaviour
{
	public abstract void OnViewEnter(float distance);
	public abstract void OnViewExit(float distance);
	public abstract void OnView(float distance);
	public abstract float GetMaximumDistance();
}

