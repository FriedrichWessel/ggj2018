using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fx_animationSpeedRandom : MonoBehaviour {

	public float _min = 0.1f;
	public float _max = 1.4f;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Animator> ().speed = Random.Range (_min, _max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
