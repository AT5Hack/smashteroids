using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	float speed;
	int lives;
	int hp;
	int currentHP;

	// Use this for initialization
	void Start () 
	{
		speed = Tweakables.Instance.player.speed;
		lives = Tweakables.Instance.player.lives;
		hp = Tweakables.Instance.player.hp;
		currentHP = hp;
	}
	
	// Update is called once per frame
	void Update () 
	{
		PollInput ();
		ConstrainPosition ();
	}

	void PollInput() 
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire ();
		}
	}

	void ConstrainPosition() 
	{

	}

	void Fire()
	{

	}

	public bool IsAlive() {
		return (currentHP > 0f);
	}
}
