using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HelloMod.Mod
{
	public class TopHat : WearableProduct
    {

		public void configure()
		{
			var resources = ScriptableObject.CreateInstance< Resource> ();
			resources.costs = 0.2f;
			resources.getResourceSettings ().percentage = 1f;


			Ingredient topHatIngridents = new Ingredient ();
			topHatIngridents.defaultAmount = 1.0f;
			topHatIngridents.resource = resources;


			ingredients = new Ingredient[]{topHatIngridents };

			//default price for a hat
			defaultPrice = 1.0f;
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
