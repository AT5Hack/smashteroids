using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float speed;
	

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.GetComponent<PlayerShip> ();
		if (player != null)
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
