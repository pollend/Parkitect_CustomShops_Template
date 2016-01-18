using HelloMod.Mod;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace HelloMod
{
    public class CustomShopLoader : MonoBehaviour
    {
		public Main Main;
		private List< UnityEngine.Object> _registeredObjects = new List<UnityEngine.Object>();

		public CustomShopLoader()
        {
        }

		public void Load()
		{
			GameObject topHatObject = LoadAsset<GameObject>("TopHatPrefab");
			var topHat = topHatObject.AddComponent<TopHat>();
			topHat.configure ();
			AssetManager.Instance.registerObject (topHat);

			GameObject topHatShopObject = LoadAsset<GameObject> ("ShopPrefab");
			var topHatShop = topHatShopObject.AddComponent<TopHatShop> ();
			topHatShop.Configure (new GameObject[]{ topHatObject });
			AssetManager.Instance.registerObject (topHatShop);


		}

		public void Unload()
		{
			foreach (UnityEngine.Object gameObjects in _registeredObjects)
			{
				AssetManager.Instance.unregisterObject(gameObjects);
			}
		}

		public T  LoadAsset<T>(string prefabName) where T : UnityEngine.Object
		{
			try
			{
				T asset;

				char dsc = System.IO.Path.DirectorySeparatorChar;
				using (WWW www = new WWW("file://" + Main.Path + dsc + "assetbundle" + dsc + "TopHats"))
				{
		
					if (www.error != null)
					{
						Main.Log("Loading had an error:" + www.error);
						Debug.Log("Loading had an error:" + www.error);
						throw new Exception("Loading had an error:" + www.error);
					}
					if(www.assetBundle == null)
					{
						Main.Log("assetBundle is null");
						Debug.Log("Loading had an error:" + www.error);
						throw new Exception("assetBundle is null");

					}
					AssetBundle bundle = www.assetBundle;


					try
					{
						asset = bundle.LoadAsset<T>(prefabName);
						_registeredObjects.Add(asset);
						bundle.Unload(false);

						return asset;
					}
					catch (Exception e)
					{
						Debug.Log(e);

						Main.LogException(e);
						bundle.Unload(false);
						return null;
					}
				}
			}
			catch (Exception e)
			{
				Main.LogException(e);
				return null;
			}
		}

    }
}
