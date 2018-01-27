using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
	public Behaviour NextBehaviour;
	public virtual void Activate()
	{
	}

	public virtual void DeactivateBehaviour()
	{
		if (NextBehaviour != null)
		{
			NextBehaviour.Activate();
		}
	}
}
