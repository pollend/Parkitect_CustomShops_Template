using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using CustomShops;

namespace CustomShops
{
	public class WerableProductDecorator : IDecorator
	{
		private string _name;
		public WerableProductDecorator (string name)
		{
			this._name = name;
		}

		public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
		{
			var product = go.AddComponent<WerableProductInstance> ();

			BindingFlags flags = BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic;
			typeof(Product).GetField ("displayName", flags).SetValue (product, _name);

			product.defaultPrice = (float)(double)options ["price"];


            if (options.ContainsKey ("hand")) {
                switch((string)options["hand"])
                {
                case "left":
                    product.handSide = Hand.Side.LEFT;
                    break;
                case "right":
                    product.handSide = Hand.Side.RIGHT;
                    break;
                }
            }

			switch ((string)options ["bodylocation"]) {
			case "head":
				product.bodyLocation = WearableProduct.BodyLocation.HEAD;
					break;
			case "face":
				product.bodyLocation = WearableProduct.BodyLocation.FACE;
					break;
			case "back":
				product.bodyLocation = WearableProduct.BodyLocation.BACK;
					break;

			}

			if (options.ContainsKey ("hideonrides")) {
				product.hideOnRides = (bool)options ["hideonrides"];
			} else
				product.hideOnRides = false;


			if (options.ContainsKey ("hidehair")) {
				product.dontHideHair = !(bool)options ["hidehair"];
			} else
				product.dontHideHair = true;



		}
	}
}

