using System;

namespace CustomShops
{
	public class ConsumableProductInstance : ConsumableProduct
	{
		public ConsumableProductInstance()
		{

		}
		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}
	}
}

