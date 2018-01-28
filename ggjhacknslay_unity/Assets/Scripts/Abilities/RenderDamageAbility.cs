using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RenderDamageAbility : Ability
{
	public HealthData Data;
	public Animator Animator;  
	public GameObject TheModel;

	private float _lastSeenData;
	private bool _firstUpdate = true; 
	private float _flickerTime;
	private float _currentFlickerValue;

	[Inject]
	void Init()
	{
		_lastSeenData = Data.CurrentHealth;
	}

	void OnDestroy() {
		StopAllCoroutines();
	}

	// Update is called once per frame
	void Update () {
		if (_firstUpdate)
		{
			_lastSeenData = Data.CurrentHealth;
			_firstUpdate = false;
		}
		if (_lastSeenData != Data.CurrentHealth)
		{
			_lastSeenData = Data.CurrentHealth;
			Animator.SetTrigger("Hit");
			StopAllCoroutines ();
			StartCoroutine ("FlickerMaterial");
		}
	}

	IEnumerator FlickerMaterial () {
		yield return Fade (1f, 0.2f);
		yield return Fade (1f, -0.2f);
		yield return Fade (1f, 0.2f);
		yield return Fade (1f, -0.2f);
	}

	IEnumerator Fade (float fadeTime, float fadeValue) {
		while(_flickerTime < fadeTime) {
			TheModel.GetComponent<MeshRenderer> ().material.SetFloat ("_ToWhite", _currentFlickerValue);
			_flickerTime += Time.deltaTime;
			_currentFlickerValue += fadeValue;
			yield return null;
		}
	}
}
