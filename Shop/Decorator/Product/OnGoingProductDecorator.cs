using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;


namespace CustomShops
{
    public class OnGoingProductDecorator : IDecorator
    {
        private string _name;
        public OnGoingProductDecorator (string name)
        {
            this._name = name;
        }

        public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
			var product = go.AddComponent< OngoingEffectProductInstance > ();
           
            BindingFlags flags = BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic;
            typeof(Product).GetField ("displayName", flags).SetValue (product, _name);


            if (options.ContainsKey ("hand")) {
                switch((string)options["hand"])
                {
                case "left":
                    product.handSide = Hand.Side.LEFT;
                    break;
                case "right":
                    product.handSide = Hand.Side.RIGHT;
                    break;
                }
            }
            product.duration = (int)(Int64)options ["duration"];
            

        }

    }
}

