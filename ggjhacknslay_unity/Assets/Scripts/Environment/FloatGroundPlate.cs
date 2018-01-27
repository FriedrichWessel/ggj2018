using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Zenject;

public class FloatGroundPlate : MonoBehaviour
{

	public AnimationCurve Curve;
	public float AnimationTime; 
	private GameModel _model;
	
	private bool LockInPlace = false;
	private Vector3 _startPos;
	private float _activeAnimationTime = 0;
	private float _startPosY;
	private bool Activated = false; 

	[Inject]
	private void Init(GameModel model)
	{
		_model = model;
		_startPos = this.transform.position;
		_startPosY = UnityEngine.Random.Range(-10f, -20);
		this.transform.position = new Vector3(_startPos.x, _startPosY, _startPos.z);
	}

	public void Activate()
	{
		Activated = true; 
	}

	void OnDestroy()
	{
		StopAllCoroutines();
	}

	// Update is called once per frame
	void Update ()
	{
		if (!Activated) return; 
		if (LockInPlace)
		{
			return;
		}
		LockInPlace = true;
		StartCoroutine(FlyIn());
		/*var dist = (transform.position - _model.Player.transform.position).magnitude;
		if (dist < 5)
		{
			LockInPlace = true;
			StartCoroutine(FlyIn());
		}*/
	}

	private IEnumerator FlyIn()
	{
		while (_activeAnimationTime < AnimationTime)
		{
			var pos = this.transform.position; 
			var actualY = Remap(0, _startPosY, 1, 0, Curve.Evaluate(_activeAnimationTime));
			var newPos = new Vector3(pos.x,actualY , pos.z);
			this.transform.position = newPos;
			_activeAnimationTime += Time.deltaTime;
			yield return null; 
		}
	}

	private float Remap(float oldLow, float newLow, float oldHigh, float newHigh, float value)
	{
		return newLow + (value - oldLow) * (newHigh - newLow) / (oldHigh - oldLow); 
	}
}
