using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

namespace CustomShops
{
	public class CustomShopLoader : MonoBehaviour
    {
		public Main Main;
		private List<Product> _products = new List<Product>();
		private List<BuildableObject> _buildableObjects = new List<BuildableObject>();
		public string Path;

		public void LoadShop()
		{

			try
			{
				char dsc = System.IO.Path.DirectorySeparatorChar;
				var dict = Json.Deserialize(File.ReadAllText(Path + @"/shop.json")) as Dictionary<string,object>;

				UnityEngine.Debug.Log("invalid json:" + (dict == null));

				using (WWW www = new WWW("file://" + Path + dsc + "assetbundle" + dsc + "shop"))
				{
					if(www.error != null)
						throw new Exception("Failed to Load:" + www.error);

					if(www.assetBundle == null)
					{
						throw new Exception("AssetBundle is null");
					}

					AssetBundle bundle = www.assetBundle;

					foreach(KeyValuePair<string,object> pair in dict)
					{

						var option = pair.Value as Dictionary<string,object>;

						GameObject asset = UnityEngine.Object.Instantiate(bundle.LoadAsset((string)option["model"])) as GameObject;
						asset.SetActive(false);
						new ShopSettingsDecorator().Decorate(asset,option,bundle);


						new PriceDecorator((double)option["price"]).Decorate(asset,option,bundle);
						new NameDecorator(pair.Key).Decorate(asset,option,bundle);

						asset.GetComponent<BuildableObject>().dontSerialize = true;
						asset.GetComponent<BuildableObject>().isPreview = true;
						_buildableObjects.Add(asset.GetComponent<BuildableObject>());

						foreach(GameObject productsObject in asset.GetComponent<ProductShop>().productGOs)
						{
							_products.Add(productsObject.GetComponent<Product>());
						}


						AssetManager.Instance.registerObject(asset.GetComponent<BuildableObject>());

					}
					bundle.Unload(false);

				}
				
			}
			catch(Exception e) {
				UnityEngine.Debug.LogException (e);
			}
		}

		public void UnloadShops()
		{
			foreach (BuildableObject shops in _buildableObjects)
			{
				AssetManager.Instance.unregisterObject(shops);
			}
			foreach (Product product in _products)
			{
				AssetManager.Instance.unregisterObject(product);
			}
		}



    }
}
