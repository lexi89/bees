using System;
using System.Collections.Generic;
using MEC;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class AnimationSequence : MonoBehaviour
{
	[Serializable] public class TweenData
	{
		public TweenType TweenType = TweenType.Scale;
		public EaseType EaseType;
		public AnimationCurve Curve{get{return isCustomEaseType ? CustomCurve : GetCurveFromEaseType(EaseType);}}
		[ShowIf("isCustomEaseType")]public AnimationCurve CustomCurve;
		public float Duration = 0.2f;
		public float Delay = 0f;
		[ShowIf("isScaleTween")]public Vector3 StartingScale = Vector3.one;
		[ShowIf("isScaleTween")]public Vector3 EndScale = Vector3.one;
		[ShowIf("isPosTween")]public Vector2 StartPos;
		[ShowIf("isPosTween")]public Vector2 EndPos;
		[ShowIf("isAlphaTween")] public float StartAlpha;
		[ShowIf("isAlphaTween")] public float EndAlpha;
		public bool isPosTween{ get{ return TweenType == TweenType.Position || TweenType == TweenType.AnchoredPosition; } }
		public bool isScaleTween{ get{ return TweenType == TweenType.Scale; } }
		public bool isAlphaTween{ get{ return TweenType == TweenType.Alpha; } }
		bool isCustomEaseType{ get{ return EaseType == EaseType.Custom; } }
	}
	
	[SerializeField] bool _playOnEnable;
	[SerializeField] bool _destroyOnComplete;
	[SerializeField] List<TweenData> Tweens = new List<TweenData>();
	[InfoBox("Invoked at runtime.")]
	[SerializeField] UnityEvent OnComplete;
	int tweensCompleted = 0;
	int tweensToComplete = 0;
	State startingState;
	bool isPreviewMode = false;

	public float Duration()
	{
		
		float duration = 0f;
		for (int i = 0; i < Tweens.Count; i++)
		{
			float finishTime = Tweens[i].Delay + Tweens[i].Duration;
			if (finishTime > duration) duration = finishTime;
		}
		return duration;
	}
	void OnEnable()
	{
		if (_playOnEnable) _doSequence(Segment.Update);
	}

	[ShowIf("isInScene")]
	[Button("Preview")]
	void Preview()
	{
		if (!gameObject.activeInHierarchy)
		{
			Debug.LogWarning("Gameobject needs to be in the scene to be previewed...", gameObject);
			return;
		}

		Tween.Instance.IsPreview = true;
		_doSequence(Segment.EditorUpdate,true);
	}

	public void DoSequence()
	{
		_doSequence(Segment.Update);
	}

	void _doSequence(Segment segmentType, bool isPreview = false)
	{
		isPreviewMode = isPreview;
		if (isPreview) startingState = GetState();
		tweensCompleted = 0;
		tweensToComplete = Tweens.Count;
		for (int i = 0; i < Tweens.Count; i++)
		{
			Timing.RunCoroutine(RunTween(Tweens[i]), segmentType);
		}
	}

	void OnAllTweensFinished()
	{
		if(!isPreviewMode && _destroyOnComplete) Destroy(gameObject);
		if(isPreviewMode) LoadState(startingState);
		if(!isPreviewMode) OnComplete.Invoke();
	}

	void OnTweenFinish()
	{
		tweensCompleted++;
		if (tweensCompleted == tweensToComplete)
		{
			OnAllTweensFinished();
		}
	}
 
	IEnumerator<float> RunTween(TweenData data)
	{
		if(data.Delay > 0) yield return Timing.WaitForSeconds(data.Delay);
		switch (data.TweenType)
		{
			case TweenType.Scale:
				DoScaleTween(data);
				break;
			case TweenType.Position:
				DoPositionTween(data);
				break;
			case TweenType.AnchoredPosition:
				DoAnchoredPositionTween(data);
				break;
			case TweenType.Alpha:
				DoAlpha(data);
				break;
			default:
				Debug.Log("no tween type found.");
				break;
		}
	}

	void DoAlpha(TweenData data)
	{
		CanvasGroup cg = transform.GetComponent<CanvasGroup>();
		if (cg == null)
		{
			Debug.LogWarning("Trying to do alpha change without a canvas group", gameObject);
			return;
		}
		Tween.CanvasGroupAlpha(cg, data.StartAlpha, data.EndAlpha, data.Duration, data.Delay, data.Curve,Tween.LoopType.None, null, OnTweenFinish);
	}

	void DoPositionTween(TweenData data)
	{
		RectTransform rectTrans = transform.GetComponent<RectTransform>();
		if(rectTrans != null) Debug.LogWarning("Doing a position tween on UI...", gameObject);
		//todo
	}

	void DoScaleTween(TweenData data)
	{
		Tween.LocalScale(transform, data.StartingScale, data.EndScale, data.Duration, 0f, data.Curve,Tween.LoopType.None, null, OnTweenFinish);
	}

	void DoAnchoredPositionTween(TweenData data)
	{
		RectTransform rectTrans = transform.GetComponent<RectTransform>();
		if (rectTrans == null)
		{
			Debug.LogWarning("no rect transform on " + transform.name, gameObject);
			return;
		}
		Tween.AnchoredPosition(rectTrans, data.StartPos, data.EndPos, data.Duration, 0f, data.Curve,Tween.LoopType.None, null, OnTweenFinish);
	}
	
	bool isInScene()
	{
		return gameObject.activeInHierarchy;
	}

	State GetState()
	{
		State state = new State();
		if (transform.GetComponent<RectTransform>() != null)
		{
			state.IsUi = true;
			state.AnchoredPos = transform.GetComponent<RectTransform>().anchoredPosition;
		}
		else
		{
			state.IsUi = false;
			state.Pos = transform.position;
		}

		if (transform.GetComponent<CanvasGroup>() != null)
		{
			state.Alpha = transform.GetComponent<CanvasGroup>().alpha;
		}

		return state;
	}

	void LoadState(State state)
	{
		
		if (state.IsUi)
		{
			transform.GetComponent<RectTransform>().anchoredPosition = state.AnchoredPos;
			if(transform.GetComponent<CanvasGroup>() != null)
			{
				transform.GetComponent<CanvasGroup>().alpha = state.Alpha;
			}
		}
		else
		{
			transform.position = state.Pos;
			
		}
	}

	static AnimationCurve GetCurveFromEaseType(EaseType easeType)
	{
		switch (easeType)
		{
			case EaseType.Bounce:
				return Tween.EaseBounce;
			case EaseType.In:
				return Tween.EaseIn;
			case EaseType.Linear:
				return Tween.EaseLinear;
			case EaseType.Out:
				return Tween.EaseOut;
			case EaseType.Spring:
				return Tween.EaseSpring;
			case EaseType.Wobble:
				return Tween.EaseWobble;
			case EaseType.InBack:
				return Tween.EaseInBack;
			case EaseType.InOut:
				return Tween.EaseInOut;
			case EaseType.InStrong:
				return Tween.EaseInStrong;
			case EaseType.OutBack:
				return Tween.EaseOutBack;
			case EaseType.OutStrong:
				return Tween.EaseOutStrong;
			case EaseType.InOutBack:
				return Tween.EaseInOutBack;
			case EaseType.InOutStrong:
				return Tween.EaseInOutStrong;
			default:
				return Tween.EaseLinear;
		}
	}

	struct State
	{
		public Vector3 Pos;
		public Vector2 AnchoredPos;
		public float Alpha;
		public bool IsUi;
	}
}

public enum EaseType
{
	Custom,
	Bounce,
	In,
	Linear,
	Out,
	Spring,
	Wobble,
	InBack,
	InOut,
	InStrong,
	OutBack,
	OutStrong,
	InOutBack,
	InOutStrong
}


public enum TweenType{
	Scale,
	Position,
	AnchoredPosition,
	Alpha
}
