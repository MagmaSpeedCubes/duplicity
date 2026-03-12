using System;

using UnityEngine;

using MagmaLabs;
using MagmaLabs.Economy;


public class GameManager : MonoBehaviour
{
  
    public static GameManager instance;
    public SaveManager saveManager;

    [SerializeField]private SerializableDictionary<Canvas> canvases;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            Debug.LogWarning("Multiple instances of GameManager detected. Destroying duplicate.");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    
    }
    void Start()
    {

    }

}


