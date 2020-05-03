using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Hero
{
    public Rogue()
    {
        damage = 80f;
        attackSpeed = 0.5f;
        range = 1f;
        life = 100f;
        lifeRegen = 4f;
        armor = 5f;
        magicResist = 5f;
        evadeChance = 25f;
        critChance = 20f;
        critDamage = 120f;
        ascendancyName = "";
        cooldown = 5f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Ascend(string ascendancyName)
    {
        isAscended = true;
        this.ascendancyName = ascendancyName;
        if (ascendancyName == "Assassin")
        {
            critChance = 30f;
            critDamage = 140f;
            cooldown = 30f;
        }
        else
        {
            damage = 100f;
            range = 3f;
            cooldown = 11f;
        }
    }

    public override void UseSkill(string ascendancyName)
    {
        if (ascendancyName == "")
        {
            FanOfKnives();
        }
        else if (ascendancyName == "Assassin")
        {
            Swap();
        }
        else
        {
            PierceAndDestroy();
        }
    }

    void FanOfKnives()
    {

    }

    void Swap()
    {

    }

    void PierceAndDestroy()
    {

    }
}
