using System;
using System.Collections.Generic;

namespace CustomShops
{
	public class ShopInstance : ProductShop
	{
		public ShopInstance()
		{
			//use 'FORWARD' for a normal shop (e.g. Burgers) use 'DIRECTIONAL' for directional use (e.g. Info Kiosk)
			walkableFlag = WalkableFlagType.FORWARD;
		}
		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}
		public override ShopSettings getSettings ()
		{
			//hack to get products to be configured
			if(this.products == null)
			Awake ();

			return base.getSettings ();
		}
	}
}

