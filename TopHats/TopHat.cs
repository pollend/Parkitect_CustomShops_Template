using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HelloMod.Mod
{
    public class TopHat : WearableProduct
    {
		public static TopHat LoadTopHat(CustomShopLoader shopLoader)
		{
			GameObject topHatObject = shopLoader.LoadAsset<GameObject>("TopHatPrefab");
			topHatObject.SetActive (false);

			var topHat = topHatObject.AddComponent<TopHat>();

			var resources = ScriptableObject.CreateInstance<Resource> ();
			resources.costs = 5.0f;
			resources.getResourceSettings ().percentage = .45f;
			resources.name = "top hat";

			Ingredient topHatIngridents = new Ingredient ();
			topHatIngridents.defaultAmount = 1.0f;
			topHatIngridents.resource = resources;

			topHat.ingredients = new Ingredient[]{topHatIngridents };

			topHat.defaultPrice = 10.0f;

			AssetManager.Instance.registerObject (topHat);

			return topHat;
		}
 
        public TopHat()
        {
            this.bodyLocation = BodyLocation.HEAD;

        }

        public override string getName()
        {
            return "Top Hat";
        }

		public override void Initialize ()
		{
			this.gameObject.SetActive (true);
			base.Initialize ();
		}

       
    }
}
