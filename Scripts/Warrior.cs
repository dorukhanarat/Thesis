using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior()
    {
        damage = 110f;
        attackSpeed = 0.5f;
        range = 1f;
        life = 120f;
        lifeRegen = 6f;
        armor = 13f;
        magicResist = 13f;
        evadeChance = 5f;
        critChance = 5f;
        critDamage = 110f;
        ascendancyName = "";
        cooldown = 12f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Ascend(string ascendancyName) {
        isAscended = true;
        this.ascendancyName = ascendancyName;
        if(ascendancyName == "Duelist") {
            damage = 120f;
            evadeChance = 10f;
            critChance = 10f;
            cooldown = 25f;
        }
        else {
            life = 130f;
            lifeRegen = 7.5f;
            armor = 15f;
            magicResist = 15f;
            critChance = 0f;
            cooldown = 12f;
        }
    }

    public override void UseSkill(string ascendancyName) {
        if(ascendancyName == "") {
            GroundSlam();

        }
        else if(ascendancyName == "Duelist") {
            CatOnTheParterre();
        }
        else {
            HolyArena();
        }
    } 
    void GroundSlam() {

    }
    void CatOnTheParterre() {

    }
    void HolyArena() {

    }
}
