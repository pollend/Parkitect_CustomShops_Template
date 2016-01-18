using System;
using UnityEngine;

namespace HelloMod.Mod
{
	public class TopHatShop : ProductShop
	{

		public void Configure(GameObject[] gameObjects)
		{
			this.productGOs = gameObjects;
			this.dontSerialize = false;
		}

		public TopHatShop() 
		{

		}

		public override string getName ()
		{
			return "Top Hat Shop";
		}
		
		protected override void Awake ()
		{
			base.Awake ();
		}

		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}




	}
}

