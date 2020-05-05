using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underling : Minion
{

    public Underling() {
        damage = 5f;
        range = 0.5f;
        attackSpeed = 0.5f;
        life = 7.5f;
        lifeRegen = 0.5f;
        armor = 2.5f;
        magicResist = 2.5f;
        evadeChance = 0f;
        critChance = 0f;
        critDamage = 50f;
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
