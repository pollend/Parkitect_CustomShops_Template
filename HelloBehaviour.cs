using HelloMod.Mod;
using UnityEngine;

namespace HelloMod
{
    class HelloBehaviour : MonoBehaviour
    {
        public HelloBehaviour()
        {

        }

        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.F8))
            {
                foreach (Guest g in FindObjectsOfType<Guest>())
                {
                    GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    g.addToInventory(o.AddComponent<TopHat>());
                }
            }
        }
    }
}
