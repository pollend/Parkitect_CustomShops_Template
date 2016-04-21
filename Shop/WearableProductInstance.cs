using System;

namespace CustomShops
{
	public class WearableProductInstance : WearableProduct
	{
		
		public WearableProductInstance ()
		{
			
		}

		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}
	}
}

