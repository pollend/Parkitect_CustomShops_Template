using System;

namespace CustomShops
{
	public class WerableProductInstance : WearableProduct
	{
		
		public WerableProductInstance ()
		{
			
		}

		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}
	}
}

