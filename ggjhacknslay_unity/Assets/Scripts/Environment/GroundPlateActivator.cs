using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlateActivator : MonoBehaviour
{
	public LayerMask ActivationLayer; 
	
	private void OnTriggerEnter(Collider other)
	{
		if (ActivationLayer == (ActivationLayer | (1 << other.gameObject.layer)))
		{
			var plates = gameObject.GetComponentsInChildren<FloatGroundPlate>();
			foreach (var plate in plates)
			{
				plate.Activate();
			}
		}
		this.enabled = false; 
	}
}
