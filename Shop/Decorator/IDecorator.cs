using System;
using UnityEngine;
using System.Collections.Generic;

namespace CustomShops
{
	public interface IDecorator
	{
		void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle);
	}
}

