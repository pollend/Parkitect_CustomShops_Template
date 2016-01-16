using System;
using UnityEngine;

namespace HelloMod.Mod
{
	public class TopHatShop : ProductShop
	{

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

