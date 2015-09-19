using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

	public Collider2D boundary;
	public Text PointsText;

	public GameObject EndGameScreen;

	private PlayerShip mPlayerShip;
	public PlayerShip playerShip
	{
		get { return mPlayerShip; }
	}

	int _points;
	public int Points
	{
		get
		{
			return _points;
		}
		set
		{
			_points = value;
			PointsText.text = value.ToString();
		}
	}

	void Start()
	{
		mPlayerShip = FindObjectOfType<PlayerShip>();
		EndGameScreen.SetActive(false);

	}

	public void TriggerEndGame()
	{
		EndGameScreen.SetActive(true);
	}
}
