using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
	public Behaviour NextBehaviour;
	public float WaitTimeToNext = 0.1f; 
	public virtual void Activate()
	{
	}

	public virtual void FinsishBehaviour()
	{
		StartCoroutine(ActivateNext());
	}

	public virtual void DeactivateBehaviour()
	{
		this.enabled = false; 
	}

	private IEnumerator ActivateNext()
	{
		yield return new WaitForSeconds(WaitTimeToNext);
		if (NextBehaviour != null)
		{
			NextBehaviour.Activate();
		}
		this.enabled = false; 
	}
}
