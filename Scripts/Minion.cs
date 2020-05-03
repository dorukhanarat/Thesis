using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Unit
{
    public Minion()
    {
        damage = 10f;
        range = 1f;
        attackSpeed = 0.5f;
        life = 15f;
        lifeRegen = 1f;
        armor = 5f;
        magicResist = 5f;
        evadeChance = 0f;
        critChance = 0f;
        critDamage = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
