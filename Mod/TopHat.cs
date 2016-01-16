using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HelloMod.Mod
{
    public class TopHat : WearableProduct
    {
 
        public TopHat()
        {
            this.bodyLocation = BodyLocation.HEAD;
            
        }

        public override string getName()
        {
            return "TEST";
        }

        void FixedUpdate()
        {
            //UnityEngine.Debug.Log("tick");
           // gObject.transform.position = this.handle.position;
        }
       
    }
}
