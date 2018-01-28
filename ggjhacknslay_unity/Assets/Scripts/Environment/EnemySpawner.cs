using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour {

	public Transform[] _spawnpoints;
	public Transform[] _enemies;
	int _pointCount;
	int _enemyCount;

	private DiContainer _container;

	// Use this for initialization
	[Inject]
	void Init (DiContainer container) {
		_pointCount = _spawnpoints.Length;
		_enemyCount = _enemies.Length;
		_container = container;
		//SpawnEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemies () {
		if (_enemyCount == 0)
		{
			return;
		}
		Debug.Log("Spawn" + gameObject.name);
		foreach (Transform _point in _spawnpoints) {
			if (Random.Range(0, 100) > 50) {
				int _enemy = Random.Range(0,_enemyCount-1);
				var sample = _enemies[_enemy];
				if (sample.GetComponent<Behaviour>() != null)
				{
					var newObject = _container.InstantiatePrefab(sample, _point);
					newObject.transform.Rotate(Vector3.up * Random.Range (0, 360));
					newObject.transform.SetParent(null);
					
				}
			}
		}
	}
}
