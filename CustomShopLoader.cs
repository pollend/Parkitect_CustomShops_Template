using HelloMod.Mod;
using UnityEngine;

namespace HelloMod
{
    class CustomShopLoader : MonoBehaviour
    {
		public CustomShopLoader()
        {

        }


		public void LoadShop()
		{
			EventManager.Instance.OnStartPlayingPark += () => {

			
				GameObject p = GameObject.CreatePrimitive (PrimitiveType.Cube);
				var hat = p.AddComponent<TopHat> ();

				var t = ScriptableObject.CreateInstance<Resource> ();
				t.costs = 1.0f;
				t.getResourceSettings ().percentage = .45f;
				t.name = "derp";


				Ingredient one = new Ingredient (){ resource = t };
				one.defaultAmount = 20.0f;
				hat.ingredients = new Ingredient[]{ one };

				AssetManager.Instance.registerObject (hat);

				GameObject o = GameObject.CreatePrimitive (PrimitiveType.Cube);
				o.SetActive(false);
	

				var shop = o.AddComponent<TopHatShop> ();
				shop.price = 10;
				shop.setDisplayName ("Top Hats");

				shop.productGOs = new GameObject[]{ p };
				hat.boughtFrom = shop;
				hat.defaultPrice = 12.0f;

				AssetManager.Instance.registerObject (shop);
		
			};

	
		}
    }
}
