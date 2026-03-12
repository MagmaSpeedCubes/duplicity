using UnityEngine;
using MagmaLabs.Animation;

public class CharacterVisuals : MonoBehaviour
{
    public Character character;

    [System.Serializable]
    public struct AccessorySlotBinding
    {
        public string slotKey;
        public MonodirectionalAccessoryAnimator animator;
        public bool useLeftFacingSprites;
    }

    [SerializeField] private bool applyOnStart = true;
    [SerializeField] private AccessorySlotBinding[] accessorySlots;

    private void Start()
    {
        if (applyOnStart)
        {
            ApplyCharacter(character);
        }
    }

    public void ApplyCharacter(Character newCharacter)
    {
        character = newCharacter;

        if (character == null || character.accessories == null || accessorySlots == null)
        {
            return;
        }

        for (int i = 0; i < accessorySlots.Length; i++)
        {
            AccessorySlotBinding binding = accessorySlots[i];
            if (binding.animator == null || string.IsNullOrWhiteSpace(binding.slotKey))
            {
                continue;
            }

            if (character.accessories.TryGetValue(binding.slotKey, out Item item))
            {
                binding.animator.SetItem(item, binding.useLeftFacingSprites);
            }
        }
    }

    public void ApplyAccessory(string slotKey, Item item, bool leftFacingSprites = false)
    {
        if (character == null)
        {
            return;
        }

        if (character.accessories == null)
        {
            character.accessories = new MagmaLabs.SerializableDictionary<Item>();
        }

        character.accessories.Set(slotKey, item);
        ApplyCharacter(character);
    }
}
