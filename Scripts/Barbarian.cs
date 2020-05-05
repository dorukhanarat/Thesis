using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : Hero
{

    public Barbarian()
    {
        damage = 120f;
        attackSpeed = 0.5f;
        range = 1f;
        life = 130f;
        lifeRegen = 7.5f;
        armor = 15f;
        magicResist = 15f;
        evadeChance = 0f;
        critChance = 0f;
        critDamage = 100f;
        ascendancyName = "";
        cooldown = 10f;
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
        if (ascendancyName == "Juggernaut")
        {
            life = 150f;
            lifeRegen = 10f;
            armor = 17f;
            magicResist = 17f;
            cooldown = 15f;
        }
        else
        {
            damage = 130f;
            cooldown = 10f;
        }
    }

    public override void UseSkill(string ascendancyName)
    {
        if (ascendancyName == "")
        {
            GroundSlam();
        }
        else if (ascendancyName == "Juggernaut")
        {
            Earthquake();
        }
        else
        {
            LeapSlam();
        }
    }


    public void GroundSlam()
    {
        foreach(Unit unit in enemies) {
            if((Distance(unit) <= range)) {
                unit.TakeDamage(50,"Physical");
            }
        }
    }

    public void Earthquake()
    {
        foreach(Unit unit in enemies) {
            if((Distance(unit) <= range)) {
                unit.TakeDamage(100,"Physical");
            }
        }
        foreach(Unit unit in enemies) {
            if((Distance(unit) <= range)) {
                for(int i = 0; i < 5; i++) {
                    unit.TakeDamage(10,"Physical");
                    Wait(1.0f);
                } 
            }    
        }
    }

    // Needs a jump annimation
    public void LeapSlam()
    { 
        if(target != null) {
            transform.position = target.transform.position;
            foreach(Unit unit in enemies) {
            if((Distance(unit) <= range)) {
                unit.TakeDamage(100,"Physical");
                }
            }
        }   
    }
}
