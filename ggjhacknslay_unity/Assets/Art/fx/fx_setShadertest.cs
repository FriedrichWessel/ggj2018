using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fx_setShadertest : MonoBehaviour {

	public float _wire = 0f;
	public float _scramble = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Shader.SetGlobalFloat ("_shdrWireframe", _wire);
		Shader.SetGlobalFloat ("_shdrScramble", _scramble);
	}
}
