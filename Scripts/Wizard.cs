using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Hero
{

    public Wizard()
    {
        damage = 80f;
        attackSpeed = 0.5f;
        range = 3f;
        life = 90f;
        lifeRegen = 5f;
        armor = 10f;
        magicResist = 10f;
        evadeChance = 5f;
        critChance = 0f;
        critDamage = 100f;
        ascendancyName = "";
        cooldown = 7f;
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
        if (ascendancyName == "Necromancer")
        {
            life = 100f;
            lifeRegen = 6f;
            cooldown = 20f;
        }
        else
        {
            damage = 100f;
            critChance = 10f;
            critDamage = 120f;
            cooldown = 12f;
        }
    }

    public override void UseSkill(string ascendancyName)
    {
        if (ascendancyName == "")
        {
            Fireball();
        }
        else if (ascendancyName == "Elementalist")
        {
            SummonUnderling();
        }
        else
        {
            ArcLightning();
        }
    }

    // Fireball throwing animation
    void Fireball()
    {
        if(target != null) {
            // Throw...
            target.TakeDamage(70, "Magical");
        }

    }

    void SummonUnderling()
    {
        for(int i = 0; i < 3; i++) {
            spawns.Add(new Underling());
        }
    }

    void ArcLightning()
    {
        for(int i = 0; i < 7; i++) {
            enemies[(int) Random.Range(0, enemies.Count)].TakeDamage(50,"Magical");
        }

    }


}
