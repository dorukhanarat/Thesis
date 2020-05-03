using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralMinion : Minion
{
    public bool hasDrop = false;
    public Item drop;
    public NeutralMinion()
    {
        damage = 30f;
        life = 50f;
        lifeRegen = 2.5f;
        armor = 7f;
        magicResist = 7f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDrop(Item item)
    {
        if (hasDrop)
        {
            drop = item;
        }
    }

    public void Empower()
    {
        damage += 10;
        life += 20;
    }
}
