using UnityEngine;

using MagmaLabs;
using MagmaLabs.Economy;

[CreateAssetMenu(fileName = "Character", menuName = "Economy/Character", order = 1)]
public class Character : SavableBase
{
    public SerializableDictionary<Sprite> sprites = new SerializableDictionary<Sprite>();
    public SerializableDictionary<Item> accessories = new SerializableDictionary<Item>();

    public bool HasSprites => sprites != null && sprites.Count > 0;
    public bool HasAccessories => accessories != null && accessories.Count > 0;

    protected override void OnEnable()
    {
        base.OnEnable();
        EnsureCharacterInitialized();
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        EnsureCharacterInitialized();
    }

    public Character Copy()
    {
        Character newCharacter = CreateInstance<Character>();
        newCharacter.id = id;
        newCharacter.name = name;

        CopyDictionary(sprites, newCharacter.sprites);
        CopyDictionary(accessories, newCharacter.accessories);
        CopyDictionary(tags, newCharacter.tags);

        return newCharacter;
    }

    public Character Copy(string newId)
    {
        Character newCharacter = Copy();
        newCharacter.id = newId;
        return newCharacter;
    }

    private void EnsureCharacterInitialized()
    {
        if (sprites == null)
        {
            sprites = new SerializableDictionary<Sprite>();
        }

        if (accessories == null)
        {
            accessories = new SerializableDictionary<Item>();
        }
    }

    private static void CopyDictionary<T>(SerializableDictionary<T> source, SerializableDictionary<T> destination)
    {
        if (destination == null)
        {
            return;
        }

        destination.Clear();
        if (source == null)
        {
            return;
        }

        foreach (var kvp in source.Items)
        {
            destination.Set(kvp.key, kvp.value);
        }
    }


}
