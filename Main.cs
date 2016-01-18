using UnityEngine;
using System.IO;
using System;


namespace HelloMod
{
    public class Main : IMod
    {
        private GameObject _go;
        
        public string Identifier { get; set; }
        
        public void onEnabled()
        {
            _go = new GameObject();
			var component = _go.AddComponent<CustomShopLoader>();
			component.Main = this;
			component.Load();
        }

        public void onDisabled()
        {
            UnityEngine.Object.Destroy(_go);
        }

	
		public void LogException(Exception e)
		{
			StreamWriter sw = File.AppendText(this.Path + @"/mod.log");

			sw.WriteLine(e);

			sw.Flush();

			sw.Close();
		}

		public void Log(string value)
		{
			StreamWriter sw = File.AppendText(this.Path + @"/mod.log");

			sw.WriteLine(value);

			sw.Flush();

			sw.Close();
		}



        public string Name
        {
            get { return "Top Hat Shop"; }
        }

        public string Description
        {
            get { return "Creates a shop that sells top hats to the guest"; }
        }
		public string Path { get; set; }

    }
}
