using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Unit
{
    public float cooldown;
    public string ascendancyName;
    public bool isAscended = false;
    public List<Item> items = new List<Item>();
    public List<Minion> spawns = new List<Minion>();
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

    public IEnumerator Skill() {
        UseSkill(ascendancyName);
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(Skill());
    }

    public IEnumerator Wait(float length) {
        yield return new WaitForSeconds(length);
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
