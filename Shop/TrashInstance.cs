using System;

namespace CustomShops
{
    public class TrashInstance : Trash
    {
        public TrashInstance ()
        {
        }

        public override void Initialize ()
        {
            this.gameObject.SetActive (true);

            base.Initialize ();
        }
    }
}

