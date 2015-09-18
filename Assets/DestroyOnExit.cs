using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col)
	{
		GameObject.Destroy (col.gameObject);
	}
}
