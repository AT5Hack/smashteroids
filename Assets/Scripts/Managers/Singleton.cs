using UnityEngine;
using System.Collections;

public class Singleton<T> : SingletonBase where T : MonoBehaviour
{
	/**
      Returns the instance of this singleton.
   */
	private static T instance = null;
	public static T Instance 
	{
		get
		{
			#if UNITY_EDITOR
			if ( instance == null )
			{
				Debug.LogWarning("Instance of " + typeof(T).ToString() + " not set, searching scene for one");
				instance = FindObjectOfType<T>();
			}
			#endif
			return instance;
		}
		private set
		{
			instance = value;
		}
	}

	public bool GlobalSingleton = false;
	
	void Awake ()
	{
		if(Exists() && GlobalSingleton)
			return;

		InitSingleton();
		SingletonAwake();
	}
	
	public override void InitSingleton()
	{
		if(instance != null && instance != (this as T))
		{
			Debug.LogError("Duplicate singleton of type " + typeof(T).ToString());
			Destroy(this.gameObject);
		}
		else if(instance == null)
		{
			instance = this as T;
		}
	}
	
	protected virtual void SingletonAwake(){}
	
	public static bool Exists()
	{
		return instance != null;
	}

	protected virtual void OnDestroy()
	{
		instance = null;
	}
}

