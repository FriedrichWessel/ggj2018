using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Zenject;

public class FireSignalOnEnable : MonoBehaviour {
	private GameStartSignal _gameStartSignal;
	private GameOverSignal _gameOverSignal;

	public enum SignalType
	{
		GameStart,
		GameOver
	}

	public SignalType Type; 
	[Inject]
	private void Init(GameStartSignal startSignal, GameOverSignal gameOverSignal)
	{
		_gameStartSignal = startSignal;
		_gameOverSignal =  gameOverSignal; 
	}
	
	private void OnEnable()
	{
		switch (Type)
		{
			case SignalType.GameOver: 
				_gameOverSignal.Fire();
				break; 
			case SignalType.GameStart:
				_gameStartSignal.Fire();
				break; 
		}
	}
}
