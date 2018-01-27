using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
	public float CurrentHealth { get; set; }
	public float BaseHealth;

	void Start()
	{
		CurrentHealth = BaseHealth; 
	}
}
