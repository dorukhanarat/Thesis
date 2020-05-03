using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendancyTree : MonoBehaviour
{
    public string ascendantType;
    public bool ascendancySelected = false;
    public Ascendancy[,] ascendancies = new Ascendancy[3, 3];
    // Start is called before the first frame update

    public AscendancyTree() {
        for(int i = 0; i < 3; i++) {
            for(int j = 0; j < 3; j++) {
                ascendancies[i, j] = new Ascendancy("-","-");
            }
        } 
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectAscendancy(int x, int y)
    {
        if (y == 2)
        {
            ascendancies[x, y].isSelected = true;
            ascendancySelected = true;
        }
        else
        {
            if (y == 1)
            {
                if (ascendancies[0, 2].isSelected || ascendancies[1, 2].isSelected || ascendancies[2, 2].isSelected)
                {
                    ascendancies[x, y].isSelected = true;
                    ascendancySelected = true;
                }
            }
            else
            {
                if (ascendancies[0, 1].isSelected || ascendancies[1, 1].isSelected || ascendancies[2, 1].isSelected)
                {
                    ascendancies[x, y].isSelected = true;
                    ascendancySelected = true;
                }
            }
        }
    }
    public void AssignTree()
    {
        if (ascendantType == "Berserker")
        {
            ascendancies[0, 0].title = "Cleave";
            ascendancies[0, 1].title = "Bam Bam Bam";
            ascendancies[0, 2].title = "Berserkest";
            ascendancies[1, 0].title = "Double Edged Sword";
            ascendancies[1, 1].title = "Bam Bam";
            ascendancies[1, 2].title = "Hardcore Maniac";
            ascendancies[2, 0].title = "Blood of my Enemies";
            ascendancies[2, 1].title = "Bam";
            ascendancies[2, 2].title = "No Pain No Gain";
            ascendancies[0, 0].description = "Your attacks deal area damage in front of you. Units on the side off the attacks take %30 less damage dealt.";
            ascendancies[0, 1].description = "With %10 chance to attack 3 extra time. If you have taken Bam and Bam Bam you attack 5 extra times.";
            ascendancies[0, 2].description = "Your maximum health is reduced %20. You deal %40 more damage.";
            ascendancies[1, 0].description = "You and your allies take %10 increased damage. You and your allies deal %20 more damage.";
            ascendancies[1, 1].description = "With %10 chance to attack 2 extra times. If you have taken Bam you attack 3 extra times.";
            ascendancies[1, 2].description = "Gain +50% attack speed for 2 seconds when an ally dies.";
            ascendancies[2, 0].description = "You and your allies %10 of attack damage leeched as life.";
            ascendancies[2, 1].description = "With %10 chance to attack 1 extra time.";
            ascendancies[2, 2].description = "You and your allies deal +1% more damage  per +1% missing health.";
        }
        else if (ascendantType == "Juggernaut")
        {
            ascendancies[0, 0].title = "Combat Stamina";
            ascendancies[0, 1].title = "Undying Rage";
            ascendancies[0, 2].title = "Last Resort";
            ascendancies[1, 0].title = "Devotion";
            ascendancies[1, 1].title = "Faith and Steel";
            ascendancies[1, 2].title = "Barbarism";
            ascendancies[2, 0].title = "Restless";
            ascendancies[2, 1].title = "Thick Skin";
            ascendancies[2, 2].title = "Block Master";
            ascendancies[0, 0].description = "You and your allies recover %20 of your maximum health when you block.";
            ascendancies[0, 1].description = "When you take lethal damage, you gain damage immunity for 2 seconds. After your rage ends, your life becomes 1.";
            ascendancies[0, 2].description = "You and your allies recover %20 of your maximum health when you block.";
            ascendancies[1, 0].description = "You and your allies takes %5 reduced damage.";
            ascendancies[1, 1].description = "Every 7 seconds gain 50 health.";
            ascendancies[1, 2].description = "You and your allies take %25 less damage from critical strikes.";
            ascendancies[2, 0].description = "You and your allies gain +0,1% health regen per +1% missing health.";
            ascendancies[2, 1].description = "Defences from items (armor, magic resist) are doubled.";
            ascendancies[2, 2].description = "You and your allies +15% chance to block attack damage.";
        }
        else if (ascendantType == "Necromancer")
        {
            ascendancies[0, 0].title = "Zoo";
            ascendancies[0, 1].title = "Martydom";
            ascendancies[0, 2].title = "Soulbound";
            ascendancies[1, 0].title = "Boss Minion";
            ascendancies[1, 1].title = "Bone Plating";
            ascendancies[1, 2].title = "Unexpected Attack";
            ascendancies[2, 0].title = "I see dead people";
            ascendancies[2, 1].title = "Strong Will";
            ascendancies[2, 2].title = "Mistress";
            ascendancies[0, 0].description = "Your maximum minion number increases by 4.";
            ascendancies[0, 1].description = "When a minion dies there is %25 chance to deal %50 of their maximum health to nearby enemies.";
            ascendancies[0, 2].description = "Increases to minions also effects you.";
            ascendancies[1, 0].description = "At the start of each round, one random minion becomes Mob Boss. All of the base stats are doubled.";
            ascendancies[1, 1].description = "Defences of your minions are doubled.";
            ascendancies[1, 2].description = "Your minions have %20 chance to deal double damage.";
            ascendancies[2, 0].description = "Every 5 seconds a minion died in that round revived.";
            ascendancies[2, 1].description = "Your allies have +30% more life.";
            ascendancies[2, 2].description = "Your allies deal %10 more damage. Your allies have %20 more attack speed.";
        }
        else if (ascendantType == "Elementalist")
        {
            ascendancies[0, 0].title = "Meteor";
            ascendancies[0, 1].title = "Elemental Mastery";
            ascendancies[0, 2].title = "Shatter";
            ascendancies[1, 0].title = "Died in a Flash";
            ascendancies[1, 1].title = "Deadly Ailments";
            ascendancies[1, 2].title = "Elemental Proliferation";
            ascendancies[2, 0].title = "Icy Veins";
            ascendancies[2, 1].title = "Inner Fire";
            ascendancies[2, 2].title = "Earth Shield";
            ascendancies[0, 0].description = "At the start of round you summon a Meteor from sky that deals 100 area damage.";
            ascendancies[0, 1].description = "You and your allies ignore magic resistance";
            ascendancies[0, 2].description = "You and your allies have %5 chance to instantly kill a frozen enemy.";
            ascendancies[1, 0].description = "You and your allies have +20% critical chance and critical damage against enemies affected by any ailment.";
            ascendancies[1, 1].description = "You deal %30 damage to enemies affected by any ailment.";
            ascendancies[1, 2].description = "You can spread ailments to nearby enemies with %30 chance.";
            ascendancies[2, 0].description = "You and your allies have %15 chance to freeze enemies with attacks.";
            ascendancies[2, 1].description = "You and your alles have %15 chance to ignite enemies with attacks.";
            ascendancies[2, 2].description = "You and your allies gain %20 of your maximum health as extra shield.";
        }
        else if (ascendantType == "Duelist")
        {
            ascendancies[0, 0].title = "It's time to Duel";
            ascendancies[0, 1].title = "Faster Fencer";
            ascendancies[0, 2].title = "Execute";
            ascendancies[1, 0].title = "Bloodthirst";
            ascendancies[1, 1].title = "Weapon Mastery";
            ascendancies[1, 2].title = "All-in";
            ascendancies[2, 0].title = "Long Reach";
            ascendancies[2, 1].title = "Ramp-it-up";
            ascendancies[2, 2].title = "Counter-Attack";
            ascendancies[0, 0].description = "You can only take one damage at time from melee attacks.";
            ascendancies[0, 1].description = "Your attack speed is doubled.";
            ascendancies[0, 2].description = "%20 chance to execute minions with your attacks.";
            ascendancies[1, 0].description = "You gain 5 health for each attack.";
            ascendancies[1, 1].description = "When you equip a weapon, bonus attack damage from it is doubled.";
            ascendancies[1, 2].description = "Converts all of your evade chance to critical chance.";
            ascendancies[2, 0].description = "You and your allies can attack further in a straight line and can deal damage all of the enemies in your reach. Enemies behind your target take %50 less damage.";
            ascendancies[2, 1].description = "You and your allies gain extra +10% attack damage and attack speed for each enemy you killed.";
            ascendancies[2, 2].description = "You perform swift counter-attack when you evade an attack. Deals the damage of evaded attack.";
        }
        else if (ascendantType == "Crusader")
        {
            ascendancies[0, 0].title = "Master Metal";
            ascendancies[0, 1].title = "Come to Light";
            ascendancies[0, 2].title = "Divine Sacrifice";
            ascendancies[1, 0].title = "Indestructible";
            ascendancies[1, 1].title = "Heaven's Help";
            ascendancies[1, 2].title = "Holy Protection";
            ascendancies[2, 0].title = "Divine Resort";
            ascendancies[2, 1].title = "Holy Light";
            ascendancies[2, 2].title = "Eye of the Victor";
            ascendancies[0, 0].description = "You and your allies gain +1 armor for each hit you’ve taken.";
            ascendancies[0, 1].description = "When you kill an enemy there is a %10 chance to make them join you to fight.";
            ascendancies[0, 2].description = "Enemies near you are taunted. Your minions can’t die before you.";
            ascendancies[1, 0].description = "You gain block chance equal to your armor as percentage.";
            ascendancies[1, 1].description = "At the start of the round you gain one random item for that turn.";
            ascendancies[1, 2].description = "You are immune to spells.";
            ascendancies[2, 0].description = "You and your allies have %1 damage reduction for each enemy nearby.";
            ascendancies[2, 1].description = "You mark your enemies with your attacks. Minions attacking marked target gain 5 health for each hit.";
            ascendancies[2, 2].description = "You and your allies’ attacks deal %50 magic and %50 physical damage.";
        }
        else if (ascendantType == "Assassin")
        {
            ascendancies[0, 0].title = "Escape Master";
            ascendancies[0, 1].title = "Paralyzing Venom";
            ascendancies[0, 2].title = "Assassinate";
            ascendancies[1, 0].title = "Restless Killer";
            ascendancies[1, 1].title = "Fear";
            ascendancies[1, 2].title = "In the Shadows";
            ascendancies[2, 0].title = "Ambush";
            ascendancies[2, 1].title = "Poisonous Blade";
            ascendancies[2, 2].title = "Backstab";
            ascendancies[0, 0].description = "You’re immune to critical strikes.";
            ascendancies[0, 1].description = "If the enemy has 3 poison stacks on it, they enter a paralyzing state and can’t do any action for 1 second.";
            ascendancies[0, 2].description = "You and your allies’ critical chance and critical damage bonus are doubled.";
            ascendancies[1, 0].description = "While you’re attacking a enemy whose health is under %50 of their maximum health, you gain %30 attack speed and damage against that target.";
            ascendancies[1, 1].description = "When a poisoned enemy dies, poisons on it spreads to one nearby enemy.";
            ascendancies[1, 2].description = "After you successfully deal critical damage you evade next incoming attack.";
            ascendancies[2, 0].description = "You and your allies deal +10% extra damage while attacking the same unit.";
            ascendancies[2, 1].description = "You and your allies have %25 chance inflict poison while attacking.";
            ascendancies[2, 2].description = "You and your allies have %25 chance to jump behind the enemy and deal double damage while attacking from behind.";
        }
        else if (ascendantType == "Ranger")
        {
            ascendancies[0, 0].title = "Empowered Arrows";
            ascendancies[0, 1].title = "Patient Hunter";
            ascendancies[0, 2].title = "Forest Blessing";
            ascendancies[1, 0].title = "Close Range Specialist";
            ascendancies[1, 1].title = "Pierce";
            ascendancies[1, 2].title = "Ricochet";
            ascendancies[2, 0].title = "Ignited Arrows";
            ascendancies[2, 1].title = "Artillery";
            ascendancies[2, 2].title = "Focus Fire";
            ascendancies[0, 0].description = "Every 5 seconds you shoot two arrows with +100% increased damage.";
            ascendancies[0, 1].description = "You gain evade chance equal to your critical chance.";
            ascendancies[0, 2].description = "You and you allies gain +50% attack damage and attack speed.";
            ascendancies[1, 0].description = "While attacking nearby units, you gain +30% attack damage and speed.";
            ascendancies[1, 1].description = "You and your allies can pierce enemies with your attacks.";
            ascendancies[1, 2].description = "Your attacks bounce two nearby targets.";
            ascendancies[2, 0].description = "Your attacks have +20% chance to ignite an enemy.";
            ascendancies[2, 1].description = "You and your allies can attack anywhere on the board.";
            ascendancies[2, 2].description = "Every 5 seconds you gain +100% attack speed for 3 attacks.";
        }
    }
}
