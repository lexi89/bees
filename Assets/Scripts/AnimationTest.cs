using Sirenix.OdinInspector;
using UnityEngine;

public class AnimationTest : MonoBehaviour {
	public AnimationClip _clip;
	public float _sampleTime;
	
	[Button("Test")]
	void test()
	{
		_clip.SampleAnimation(gameObject,_sampleTime);
	}
}
