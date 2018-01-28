using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform[] _spawnpoints;
	public Transform[] _enemies;
	int _pointCount;
	int _enemyCount;
	// Use this for initialization
	void Start () {
		_pointCount = _spawnpoints.Length;
		_enemyCount = _enemies.Length;
		SpawnEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemies () {
		foreach (Transform _point in _spawnpoints) {
			if (Random.Range(0, 100) > 50) {
				int _enemy = Random.Range(0,_enemyCount-1);
				Transform _new = Instantiate(_enemies[_enemy], _point);
				_new.Rotate(Vector3.up * Random.Range (0, 360));
			}
		}
	}
}
