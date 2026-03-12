using UnityEngine;
using UnityEngine.UI;

using MagmaLabs;
using MagmaLabs.Economy;

public class ItemShop : MonoBehaviour
{

    public SerializableDictionary<ShopItem> items; 


}
[System.Serializable]
public class ShopItem
{
    public Item item;
    public float cost;
    public string currency;
}
