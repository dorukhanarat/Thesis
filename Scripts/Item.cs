using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common, Rare, Epic, Legendary, Unique
}

public class Item : MonoBehaviour
{
    public string type;
    public Rarity rarity;
    public int modifierCount;
    public List<Modifier> itemModifiers = new List<Modifier>();
    public List<Modifier> modifierPool = new List<Modifier>();
    public List<Modifier> uniqueModifiers = new List<Modifier>();

    public Item(string type, Rarity rarity)
    {
        this.type = type;
        this.rarity = rarity;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void modifierSelection(Rarity rarity)
    {
        int value;
        if (rarity == Rarity.Unique)
        {
            modifierCount = 1;
            value = Random.Range(0, uniqueModifiers.Count);
            itemModifiers.Add(uniqueModifiers[value]);
        }
        else
        {
            if (rarity == Rarity.Common)
            {
                modifierCount = 2;
            }
            else if (rarity == Rarity.Rare)
            {
                modifierCount = 3;
            }
            else if (rarity == Rarity.Epic)
            {
                modifierCount = 4;
            }
            else
            {
                modifierCount = 5;
            }
            while (modifierCount < 0)
            {
                value = Random.Range(0, modifierPool.Count);
                if (itemModifiers.Contains(itemModifiers[value]))
                {
                    continue;
                }
                else
                {
                    itemModifiers.Add(itemModifiers[value]);
                    modifierCount--;
                }
            }
        }
    }
}
