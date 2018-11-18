/// <summary>
/// SURGE FRAMEWORK
/// Author: Bob Berkebile
/// Email: bobb@pixelplacement.com
/// 
/// Used internally by the tween system to run all tween calculations.
/// 
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Pixelplacement;

namespace Pixelplacement.TweenSystem
{
	public class TweenEngine : MonoBehaviour
	{
		public bool IsPreview;
		#region Public Methods
		public void ExecuteTween (TweenBase tween)
		{
			if (!IsPreview)
			{
				Timing.RunCoroutine(RunTween(tween));
			}
			else
			{
				Timing.RunCoroutine(RunTween(tween),Segment.EditorUpdate); // preview update loop.	
			}
			
		}
		#endregion

		#region Coroutines
		//execute tween:
		static IEnumerator<float> RunTween (TweenBase tween)
		{
			Tween.activeTweens.Add (tween);

			while (true) 
			{
				//tick tween:
				if (!tween.Tick ())
				{
					//clean up tween:
					Tween.activeTweens.Remove (tween);
					yield break;
				}

				//loop:
				yield return 0;	
			}
		}
		#endregion
	}
}