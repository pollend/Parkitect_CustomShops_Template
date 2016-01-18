using UnityEngine;
using System.Collections;
using UnityEditor;

public class AssetBundler : MonoBehaviour
{

	public class AssetBundleExporter
	{
		[MenuItem("Assets/Build AssetBundles")]
		static void BuildAllAssetBundles()
		{
			
			BuildPipeline.BuildAssetBundles("./../assetbundle/");
		}
	}
}
