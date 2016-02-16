using System;
using System.Collections.Generic;

namespace CustomShops
{
	public class ShopInstance : ProductShop
	{
		public ShopInstance()
		{

		}
		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}

	}
}

