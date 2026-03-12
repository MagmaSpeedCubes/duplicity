using UnityEngine;
using MagmaLabs;
public class ItemRegistry : MonoBehaviour
{
    public static ItemRegistry instance;

    public SerializableDictionary<Item> items;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogWarning("Multiple instances of ItemRegistry detected. Destroying duplicate.");
            Destroy(this);
        }
    }


}
