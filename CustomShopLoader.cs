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
		private List<GameObject> _registeredObjects = new List<GameObject>();

		public CustomShopLoader()
        {

        }

		public void Load()
		{
			var topHat = TopHat.LoadTopHat (this);
			_registeredObjects.Add (topHat.gameObject);
			_registeredObjects.Add(TopHatShop.LoadTopHatShop (this, topHat).gameObject);

			/*TopHatShop.LoadTopHatShop (this);
				GameObject p = GameObject.CreatePrimitive (PrimitiveType.Cube);
				var hat = p.AddComponent<TopHat> ();

				var Resources = ScriptableObject.CreateInstance<Resource> ();
				Resources.costs = 1.0f;
				Resources.getResourceSettings ().percentage = .45f;
				Resources.name = "derp";


				Ingredient one = new Ingredient (){ resource = Resources };
				one.defaultAmount = 20.0f;
				hat.ingredients = new Ingredient[]{ one };

				AssetManager.Instance.registerObject (hat);

				GameObject o = GameObject.CreatePrimitive (PrimitiveType.Cube);
				o.SetActive(false);
	

				var shop = o.AddComponent<TopHatShop> ();
				shop.price = 10;
				shop.setDisplayName ("Top Hats");

				shop.productGOs = new GameObject[]{ p };
				hat.boughtFrom = shop;
				hat.defaultPrice = 12.0f;

				AssetManager.Instance.registerObject (shop);*/
		}

		public void Unload()
		{
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
						Main.Log("------------------------------------------");
						Main.Log(bundle.GetAllAssetNames().Length.ToString());
						foreach(var v in bundle.GetAllAssetNames())
						{
							Main.Log(v);
						}
						Main.Log("------------------------------------------");
						asset = bundle.LoadAsset<T>(prefabName);
			
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
