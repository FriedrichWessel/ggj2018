using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using Zenject;

public class PlayerEntity : MonoBehaviour {
	private GameModel _model;

	[Inject]
	private void Init(GameModel model)
	{
		_model = model;
		_model.Player = this;
	}
}
