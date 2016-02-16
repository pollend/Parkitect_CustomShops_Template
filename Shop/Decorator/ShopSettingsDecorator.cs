using System;
using UnityEngine;
using System.Collections.Generic;
using CustomShops;

namespace CustomShops
{
	public class ShopSettingsDecorator : IDecorator
	{
		public ShopSettingsDecorator ()
		{
		}

		public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
		{
			ShopInstance shop = go.AddComponent<ShopInstance>();

			List<GameObject> products = new List<GameObject> ();
			foreach (KeyValuePair<string,object> pair in options["products"] as Dictionary<string,object>) {
				products.Add(new ProductDecorator (pair.Key).Decorate (pair.Value as Dictionary<string,object>, assetBundle));

			}
			shop.productGOs = products.ToArray ();


		}
	}
}

