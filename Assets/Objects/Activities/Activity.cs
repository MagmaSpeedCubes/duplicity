using UnityEngine;

using MagmaLabs;

public class CardEvent : ScriptableObject
{
    public string name, id;
    public Sprite icon;
    public string description;
    public int declineTokenCost;
}

[CreateAssetMenu(fileName = "Course", menuName = "Scriptable Objects/Course")]
public class Course : CardEvent
{

    public int acceptRecurringStressCost;
}

[CreateAssetMenu(fileName = "Extracurricular", menuName = "Scriptable Objects/Extracurricular")]
public class Extracurricular : CardEvent
{

    public int acceptRecurringStressCost;
    public int acceptRecurringTokenReward;
}

[CreateAssetMenu(fileName = "Event", menuName = "Scriptable Objects/Event")]
public class Event : CardEvent
{


    public int acceptTokenReward, acceptStressCost;

}
