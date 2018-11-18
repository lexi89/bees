using System.Linq;
using UnityEngine;

public abstract class ScriptableSingleton<T> : ScriptableObject where T: ScriptableObject {

	static T _instance;
	
	public static T Instance{
		get{
			if (!_instance)
				_instance = FindObjectOfType<T>();
			if (!_instance)
				_instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
			if (!_instance)
				_instance = Resources.Load<T>("");
			if (!_instance)
				Debug.LogError(typeof(T) + " singleton hasn't been created yet. ");
			return _instance;
		}
	}
}
