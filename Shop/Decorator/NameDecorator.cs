using System;
using UnityEngine;
using System.Collections.Generic;

namespace CustomShops
{
	public class NameDecorator
	{
		private string _name;

		public NameDecorator(string name)
		{
			_name = name;
		}

		public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
		{
			
			go.GetComponent<BuildableObject>().setDisplayName(_name);
			go.name = _name;
		}
	}
}

