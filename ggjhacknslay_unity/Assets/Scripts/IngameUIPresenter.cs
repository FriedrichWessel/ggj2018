using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IngameUIPresenter : MonoBehaviour {
	private GameStartSignal _gameStartSignal;
	private GameOverSignal _gameOverSignal;

	public Animator Animator; 

	[Inject]
	private void Init(GameStartSignal startSignal, GameOverSignal gameOverSignal)
	{
		_gameStartSignal = startSignal;
		_gameOverSignal = gameOverSignal;
		_gameStartSignal += ShowUI;
		_gameOverSignal += HideUI; 
	}

	void OnDestroy()
	{
		_gameStartSignal -= ShowUI;
		_gameOverSignal -= HideUI; 
	}

	private void HideUI()
	{
		Animator.SetTrigger("Hide");
	}

	private void ShowUI()
	{
		Animator.SetTrigger("Show");
	}
}
