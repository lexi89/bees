using Pixelplacement;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] AnimationCurve _spawnAnimCurve;
	[SerializeField] AnimationCurve _despawnAnimCurve;

	public void SpawnAnim(Transform _target)
	{
		Tween.LocalScale(_target,Vector3.zero, _target.localScale, 0.2f, 0f, _spawnAnimCurve);
	}
	
	public void DespawnAnim(Transform _target)
	{
		Tween.LocalScale(_target,_target.localScale, Vector3.zero, 0.2f, 0f, _despawnAnimCurve);
	}
}
