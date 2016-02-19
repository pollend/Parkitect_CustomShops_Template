using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace CustomShops
{
	public class ConsumableProductDecorator : IDecorator
	{
		private string _name;
		public ConsumableProductDecorator (string name)
		{
			this._name = name;
		}

		public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
		{
			var consumable = go.AddComponent<ConsumableProductInstance> ();

			BindingFlags flags = BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic;
			typeof(Product).GetField ("displayName", flags).SetValue (consumable, _name);

			consumable.defaultPrice = (float)(double)options ["price"];

            if (options.ContainsKey ("hand")) {
                switch((string)options["hand"])
                {
                case "left":
                    consumable.handSide = Hand.Side.LEFT;
                    break;
                case "right":
                    consumable.handSide = Hand.Side.RIGHT;
                    break;
                }
            }


			if (options.ContainsKey ("consumeanimation")) {
				switch ((string)options ["consumeanimation"]) {
				case "generic":
					consumable.consumeAnimation = ConsumableProduct.ConsumeAnimation.GENERIC;
					break;
				case "drink_straw":
					consumable.consumeAnimation = ConsumableProduct.ConsumeAnimation.DRINK_STRAW;
					break;
				case "lick":
					consumable.consumeAnimation = ConsumableProduct.ConsumeAnimation.LICK;
					break;
				case "with_hands":
					consumable.consumeAnimation = ConsumableProduct.ConsumeAnimation.WITH_HANDS;
					break;

				}
			} else {
				consumable.consumeAnimation = ConsumableProduct.ConsumeAnimation.GENERIC;
			}

			if (options.ContainsKey ("temprature")) {
				switch ((string)options ["temprature"]) {
				case "none":
					consumable.temperaturePreference = ConsumableProduct.TemperaturePreference.NONE;
					break;
				case "cold":
					consumable.temperaturePreference = ConsumableProduct.TemperaturePreference.COLD;
					break;
				case "hot":
					consumable.temperaturePreference = ConsumableProduct.TemperaturePreference.HOT;
					break;
				}
			} else {
				consumable.temperaturePreference = ConsumableProduct.TemperaturePreference.NONE;
			}
			consumable.portions = (int)(Int64)options ["portions"];
		}
	}
}

