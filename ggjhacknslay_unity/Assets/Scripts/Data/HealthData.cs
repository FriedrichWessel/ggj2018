using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
	public float CurrentHealth { get; set; }
	public float BaseHealth;
	public DamageAbility LastDamageDealer;
	public string Name;

	void Start()
	{
		CurrentHealth = BaseHealth; 
	}
}
