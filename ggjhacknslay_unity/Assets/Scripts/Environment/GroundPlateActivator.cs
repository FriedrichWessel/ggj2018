using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlateActivator : MonoBehaviour
{
	public LayerMask ActivationLayer;
	private bool activated = false; 
	private void OnTriggerEnter(Collider other)
	{
		if(activated)
			return;
	
		if (ActivationLayer == (ActivationLayer | (1 << other.gameObject.layer)))
		{
			activated = true; 
			var plates = gameObject.GetComponentsInChildren<FloatGroundPlate>();
			foreach (var plate in plates)
			{
				plate.Activate();
			}
			var spawner = gameObject.GetComponent<EnemySpawner>();
			if (spawner != null)
			{
				spawner.SpawnEnemies();
			}
			this.enabled = false; 
		}
	}
}
