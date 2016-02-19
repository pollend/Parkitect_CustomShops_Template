using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace CustomShops
{
	public class ProductDecorator : IDecorator
	{
		private string _name;
		public ProductDecorator (string name)
		{
			this._name = name;
		}

		public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
		{
			switch ((string)options ["type"]) {
			case "wearable":
				new WerableProductDecorator (_name).Decorate (go, options, assetBundle);
				break;
			case "consumable":
				new ConsumableProductDecorator (_name).Decorate (go, options, assetBundle);
				break;
            case "ongoing":
                new OnGoingProductDecorator(_name).Decorate(go,options,assetBundle);
                break;
			default:
				UnityEngine.Debug.Log ("illegal type");
				break;
			}

			List<Ingredient> ingredients = new List<Ingredient> ();
			foreach (KeyValuePair<string,object> collection in options["ingredients"] as Dictionary<string,object>) {
				var dictIngredient = collection.Value as Dictionary<string,object>;
				var resource = ScriptableObject.CreateInstance< Resource> ();
				resource.name = collection.Key;
				resource.setDisplayName (collection.Key);
				resource.costs = (float)(double)dictIngredient ["price"];
				resource.getResourceSettings ().percentage = 1f;
				if (dictIngredient.ContainsKey ("effects")) {
					List<ConsumableEffect> consumableEffects = new List<ConsumableEffect> ();

					foreach (object temp in dictIngredient["effects"] as List<object>) {
						Dictionary<string,object> effect = (Dictionary<string,object>)temp; 
						var consumableEffect = new ConsumableEffect ();
						switch ((string)effect ["affectStat"]) {
						case "hunger":
							consumableEffect.affectedStat = ConsumableEffect.AffectedStat.HUNGER;
							break;
						case "thirst":
							consumableEffect.affectedStat = ConsumableEffect.AffectedStat.THIRST;
							break;
						case "happiness":
							consumableEffect.affectedStat = ConsumableEffect.AffectedStat.HAPPINESS;
							break;
						case "tiredness":
							consumableEffect.affectedStat = ConsumableEffect.AffectedStat.TIREDNESS;
							break;
						case "sugerboost":
							consumableEffect.affectedStat = ConsumableEffect.AffectedStat.SUGARBOOST;
							break;
						}
						consumableEffect.amount = (float)(double)effect ["amount"];
						consumableEffects.Add (consumableEffect);
					}
					resource.effects = consumableEffects.ToArray ();
				}
				Ingredient ingredient = new Ingredient ();
				ingredient.defaultAmount = (float)(double)dictIngredient ["amount"];
				ingredient.tweakable = (bool)dictIngredient ["tweakable"];
				AssetManager.Instance.registerObject (resource);
				ingredient.resource = resource;
				ingredients.Add (ingredient);

			}
			go.gameObject.GetComponent<Product> ().ingredients = ingredients.ToArray ();

		}


		public GameObject Decorate(Dictionary<string, object> options, AssetBundle assetBundle)
		{
			var asset = UnityEngine.Object.Instantiate(assetBundle.LoadAsset((string)options["model"])) as GameObject;

			asset.gameObject.SetActive (false);
			this.Decorate (asset,options, assetBundle);
			AssetManager.Instance.registerObject (asset.gameObject.GetComponent<Product> ());
			return asset;
		}
	}
}

