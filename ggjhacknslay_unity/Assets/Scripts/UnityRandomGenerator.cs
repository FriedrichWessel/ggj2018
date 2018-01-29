using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnityRandomGenerator : IRandomGenerator {
	private Random _rnd;

	public float Range(float includingMin, float includingMax)
	{
		return UnityEngine.Random.Range(includingMin, includingMax);
	}
}
