using System;
using UnityEngine;

public class ItemConfiguration : ScriptableObject
{
	public Item[] AvailableHeadItems;
	public Item[] AvailableBodyItems;
#if UNITY_EDITOR

	[UnityEditor.MenuItem("Tools/CreateItemConfig")]
	public static void CreateItemConfig()
	{
		var config = ScriptableObject.CreateInstance<ItemConfiguration>();
		UnityEditor.AssetDatabase.CreateAsset(config, "Assets/ItemConfig.asset");
		UnityEditor.AssetDatabase.Refresh();
	}

#endif
	

}
