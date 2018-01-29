using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfiguration : ScriptableObject {

	public GameObject[] AvailableEnemies;
	
#if UNITY_EDITOR

	[UnityEditor.MenuItem("Tools/CreateEnemyConfig")]
	public static void CreateItemConfig()
	{
		var config = ScriptableObject.CreateInstance<EnemyConfiguration>();
		UnityEditor.AssetDatabase.CreateAsset(config, "Assets/EnemyConfig.asset");
		UnityEditor.AssetDatabase.Refresh();
	}

#endif
}
