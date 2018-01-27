using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
	public Behaviour NextBehaviour;
	public virtual void Activate()
	{
	}

	public virtual void DeactivateBehaviour()
	{
		this.enabled = false; 
		if (NextBehaviour != null)
		{
			NextBehaviour.Activate();
		}
	}
}
