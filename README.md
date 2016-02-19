#Parkitect Custom Shops Template

##Sample Json

```json
{
	"cube" : {
		"model":"model1",
		"price": 20.5,
		"products": {
			"A": {
                "model":"model2",
                "price": 1.5,
                "type" : "wearable",
                "bodylocation" : "head",
                "hideonrides" : false,
                "hidehair" : true,
                "ingredients": {
                    "ingredient2" :{
                     "price": 1.0,
                     "amount" : 10.0,
                     "tweakable" : false
                    },
                    "ingredient1" :{
                     "price": 1.0,
                     "amount" : 1.0,
                     "tweakable" : true
                    }
                }
            },
			"B": {
				"model":"model3",
				"price": 1.5,
				"type" : "consumable",
				"temprature" : "hot",
                "hand" : "left",
				"consumeanimation" : "generic", 
				"portions" : 10,
				"ingredients": {
					"ingredient1" :{
					 "price": 1.0,
					 "amount" : 1.0,
					"tweakable" : false,
					"effects": [
					{
						"affectStat" : "hunger",
						"amount" : -.9
					}]
						
					}
				}
			}
		}
	}
}
```

##Models

In terms of model's there isn't much to configure other then the prefab itself. 

A child object named ```handle``` can denote how the object is either held or placed on the npc. This only applys to the products and not the shop itself.

##Products

```"hand" : "left"```

denotes the hand that the product will appear in


prodcuts are what your shop is selling. there are three types of products in the game and they include wearable, consumable and ongoing effect products.

```json
"effects": [
{
	"affectStat" : "hunger",
	"amount" : -0.4
}
]
```

effects are stat based effects for any given npc. they are divided into ``` hunger/thirst/happiness/tiredness/sugarboost ```.
wearable product I believe are not effects by these stats. ongoing products will be effect the npc by the tick while consumable products are only active when an npc consumes the product. amount is bounded between 0 and -1. 



```json 
"ingredients": {
	"ingredient2" :{
	 "price": 1.0,
	 "amount" : 10.0,
	 "tweakable" : false
	}
}
```
ingredients are what your product is composed of. amount is in amounts of 100 so a value of 2.0 will yield 200 of that ingredient for that shop. tweakable will allow the player to tweak the amount of that ingredient added to that associated product. the key value will denote the name of that product. 


##Wearable Products
 
Wearable products are anything that an npc can wear. In terms of the prefab, a 

``` bodylocation: head/face/back ```

the location where the product will appear on the npc.

##Consumable Products

``` consumeanimation : generic/drink_straw/lick/with_hands ```

denotes which animation will be used to consume the product

``` temprature: none/cold/hot ```

denotes the the temprature that an npc will prefer to buy this product

```"portions" : 10```

the amount of poritions that the product will offer to the npc

###Ongoing Effect Products

```"duration" : 1000```

the duration that the npc will use the product. 



