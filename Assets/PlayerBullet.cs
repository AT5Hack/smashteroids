using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	int speed;

	// Use this for initialization
	void Start () {
		speed = Tweakables.Instance.player.bulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var enemy = other.GetComponent<EnemyShip> ();
		if (enemy != null)
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
