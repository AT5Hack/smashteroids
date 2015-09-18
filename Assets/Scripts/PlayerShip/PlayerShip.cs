using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerShip : MonoBehaviour {

	[Serializable]
	public class BulletSpawn
	{
		public float angle;
		public Vector3 offset;
	}

	public List<BulletSpawn> bulletSpawns;

	float speed;
	int hp;
	bool controlLocked;
	int damageTaken;

	float fireSpeed = 0.2f;

	float lastFire = 0;

	// Use this for initialization
	void Start () 
	{
		speed = Tweakables.Instance.player.speed;
		hp = Tweakables.Instance.player.hp;
		fireSpeed = Tweakables.Instance.player.fireSpeed;

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
		Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));

		if (Input.GetButton("Fire1"))
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
		transform.position = GameManager.Instance.boundary.bounds.ClosestPoint (transform.position);

	}

	void Fire()
	{
		if (Time.time < lastFire + fireSpeed)
			return;

		lastFire = Time.time;

		foreach(var spawn in bulletSpawns)
		{
			// load and instantiate the bullet
			var bulletPrefab = Resources.Load("PlayerBullet");
			var bulletGo = (GameObject) GameObject.Instantiate(bulletPrefab);
			var bullet = bulletGo.GetComponent<PlayerBullet>();

			// rotate bullet
			var rotation = bullet.transform.localRotation.eulerAngles;
			rotation.z = spawn.angle;
			bullet.transform.localRotation = Quaternion.Euler(rotation);

			// fire bullet from ship's position and apply offset
			bullet.transform.position = transform.position + spawn.offset;
		}
	}
	
	public bool IsAlive() {
		return (damageTaken < hp);
	}

	void Die()
	{
		Dispatcher.FireEvent (this, new PlayerDeathEvent ());

		gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		DamagePlayer hazard = collider.GetComponent<DamagePlayer> ();

		if (hazard != null)
		{
			damageTaken += hazard.damage;

			if (damageTaken >= hp)
			{
				Die();
			}
		}
	}
}
