using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Unit
{
    public float cooldown;
    public string ascendancyName;
    public bool isAscended = false;
    public List<Item> items = new List<Item>();
    public bool newItemTaken = false;
    public Hero()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Ascend(string ascendancyName);

    public abstract void UseSkill(string ascendancyName);

    public void TakeItem(Item newItem)
    {
        foreach (Item item in items)
        {
            if (item.type == newItem.type)
            {
                items.Remove(item);
            }
        }
        items.Add(newItem);
        newItemTaken = true;
    }

}
