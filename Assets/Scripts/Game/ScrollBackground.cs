using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

	public float speed;

	public float wrapAmount;

	void Update () 
	{
		transform.Translate (Vector3.left * speed * Time.deltaTime);

		if(transform.position.x <= -wrapAmount)
		{
			var pos = transform.localPosition;
			pos.x += wrapAmount*2;
			transform.localPosition = pos;
		}
	}
}
