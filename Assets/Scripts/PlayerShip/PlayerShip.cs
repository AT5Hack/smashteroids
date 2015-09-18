using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	float speed;
	int lives;
	int hp;
	bool controlLocked;
	int damageTaken;

	// Use this for initialization
	void Start () 
	{
		speed = Tweakables.Instance.player.speed;
		lives = Tweakables.Instance.player.lives;
		hp = Tweakables.Instance.player.hp;

		StartCoroutine (ForceMovement(Vector3.right, 5));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!controlLocked)
		{
			PollInput ();
			ConstrainPosition ();
		}

		if (damageTaken >= hp)
		{
			Die();
		}

	}

	/// <summary>
	/// Locks player input and moves in the specified direction.
	/// </summary>
	/// <param name="direction">Direction to move.</param>
	/// <param name="distance">Distance to move in units.</param>
	IEnumerator ForceMovement(Vector3 direction, float distance)
	{
		controlLocked = true;

		float distanceTraveled = 0;

		// move forward until destination is reached
		while (distanceTraveled < distance)
		{
			Vector3 oldPosition = transform.position;
			Move (direction);
			distanceTraveled += Vector3.Distance(oldPosition, transform.position);

			yield return null; // wait until next frame
		}

		controlLocked = false;
	}

	void PollInput() 
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Move(Vector3.up);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			Move(Vector3.down);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Move(Vector3.left);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Move(Vector3.right);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire ();
		}
	}

	void Move(Vector3 direction)
	{
		transform.Translate(direction * speed * Time.deltaTime);
	}

	void ConstrainPosition() 
	{

	}

	void Fire()
	{

	}

	void Die()
	{
		Dispatcher.FireEvent (this, new PlayerDeathEvent ());
	}
}
