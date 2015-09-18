using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollBackground : MonoBehaviour {

	public float speed;
	public float wrapAmount;

	public List<Transform> bgChunks;

	void Update () 
	{
		var moveAmount = Vector3.left * speed * Time.deltaTime;

		foreach (Transform chunk in bgChunks)
		{
			chunk.Translate (moveAmount);
			
			if(chunk.localPosition.x <= -wrapAmount)
			{
				var pos = chunk.localPosition;
				pos.x += wrapAmount*2;
				chunk.localPosition = pos;
			}
		}

	}
}
