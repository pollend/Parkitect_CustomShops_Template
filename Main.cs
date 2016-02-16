using UnityEngine;
using System.IO;
using System;


namespace CustomShops
{
    public class Main : IMod
    {
        private GameObject _go;
        
        public void onEnabled()
        {
           _go = new GameObject();
			var component = _go.AddComponent<CustomShopLoader>();
			component.Path = Path;
			component.LoadShop ();
        }

        public void onDisabled()
        {
			_go.GetComponent<CustomShopLoader> ().UnloadShops ();
            UnityEngine.Object.Destroy(_go);
        }



		public string Name { get { return "Custom Shop Pack"; } }
		public string Description { get { return "Custom Shop Pack"; } }
		public string Path { get; set; }
		public string Identifier { get; set; }
    }
}
