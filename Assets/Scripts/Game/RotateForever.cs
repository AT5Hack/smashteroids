using UnityEngine;
using System.Collections;

public class RotateForever : MonoBehaviour {

	public float speed;

	void Update() {
		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
