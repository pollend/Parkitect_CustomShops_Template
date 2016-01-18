using System;
using UnityEngine;

namespace HelloMod.Mod
{
	public class TopHatShop : ProductShop
	{

		public static TopHatShop LoadTopHatShop(CustomShopLoader shopLoader,TopHat tophat)
		{
			GameObject topHatShopObject = shopLoader.LoadAsset<GameObject>("ShopPrefab");
			topHatShopObject.SetActive (false);

			//------------------------SHOP------------------------------
			var topHatShop = topHatShopObject.AddComponent<TopHatShop>();

			topHatShop.name = "Top Hat Shop";
			topHatShop.price = 20.0f;

			topHatShop.productGOs = new GameObject[]{ tophat.gameObject };

			AssetManager.Instance.registerObject (topHatShop);

			return topHatShop;
		}


		public TopHatShop()
		{
			
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

