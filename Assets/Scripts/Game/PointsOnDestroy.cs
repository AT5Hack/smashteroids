using UnityEngine;

public class PointsOnDestroy : MonoBehaviour
{

	public int Points = 100;

	void OnDestroy()
	{
		if(GameManager.Instance != null && GameManager.Instance.PointsText != null)
		{
			GameManager.Instance.Points += Points;
		}
	}
}
