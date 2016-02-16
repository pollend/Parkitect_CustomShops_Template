using System;
using UnityEngine;
using System.Collections.Generic;

namespace CustomShops
{
	public class PriceDecorator : IDecorator
	{
		private double _price;
		public PriceDecorator (double price)
		{
			this._price = price;
		}

		public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
		{
			go.GetComponent<BuildableObject>().price = (float) _price;
		}
	}
}

