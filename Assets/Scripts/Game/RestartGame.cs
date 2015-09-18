using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour
{

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
