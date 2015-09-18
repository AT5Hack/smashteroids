using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyWhenFinished : MonoBehaviour {
	
	private ParticleSystem ps;
	
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	void Update () {
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}