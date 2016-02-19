using System;


	public class OngoingEffectProductInstance : OngoingEffectProduct
	{
		public OngoingEffectProductInstance ()
		{
		}

		public override void Initialize ()
		{
			this.gameObject.SetActive (true);

			base.Initialize ();
		}
	}
