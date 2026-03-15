using UnityEngine;

using MagmaLabs;
public class EndScreenManager : MonoBehaviour
{
    public SerializableDictionary<EndScreenController> endScreens;

    public void DisplayEndScreen(string key)
    {
        endScreens[key].Display();
    }
}
