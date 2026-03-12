using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private Canvas endScreen;

    void Awake()
    {
        endScreen.enabled = false;
    }

    public void ShowWinScreen()
    {
        endScreen.enabled = true;
    }

    public void ShowLossScreen()
    {
        endScreen.enabled = true;
    }
}
