using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int skillPoints;
    [SerializeField] public int ascendancyPoints;
    public Hero hero;
    public List<Minion> minions = new List<Minion>();
    public List<Unit> units = new List<Unit>();
    public List<Item> inventory = new List<Item>();
    public RoundManager roundManager;
    public PassiveTree passiveTree;
    public AscendancyTree ascendancyTree;
    public List<Ascendancy> ascendancyList = new List<Ascendancy>();
    public Board board;
    public bool isMatched = false;
    // Start is called before the first frame update

    public Player() {
        roundManager = new RoundManager();
        ascendancyTree = new AscendancyTree();
        passiveTree = new PassiveTree();
    }

    void Start()
    {
        foreach (Unit unit in units)
        {
            int x = Random.Range(0, 8);
            int y = Random.Range(4, 8);
            if (board.tiles[x, y] == null)
            {
                board.tiles[x, y].unit = unit;
            }
            else
            {
                while (board.tiles[x, y] != null)
                {
                    x = Random.Range(0, 8);
                    y = Random.Range(4, 8);
                }
                board.tiles[x, y].unit = unit;
            }
        }
        ascendancyTree.AssignTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (ascendancyTree.ascendancySelected)
        {
            ascendancyTree.AssignTree();
            ascendancyTree.ascendancySelected = false;

            if (hero.isAscended)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (ascendancyTree.ascendancies[i, j].isSelected)
                        {
                            if (!ascendancyList.Contains(ascendancyTree.ascendancies[i, j]))
                            {
                                ascendancyList.Add(ascendancyTree.ascendancies[i, j]);
                            }
                        }
                    }
                }
            }
        }

        if (roundManager.roundEnded)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board.tiles[i, j] = roundManager.board.tiles[i, j];
                }
            }
            foreach (Unit enemy in roundManager.enemies)
            {
                foreach (Unit unit in units)
                {
                    unit.enemies.Add(enemy);
                }
            }
        }

        if (passiveTree.newNodeSelected)
        {
            skillPoints--;
            TreeUpgrade();
            passiveTree.newNodeSelected = false;
        }
        if (hero.newItemTaken)
        {
            ItemUpgrade();
            hero.newItemTaken = false;
        }
    }

    public void SelectUnit()
    {
        foreach(Unit unit in units) {
            if(unit.unitSelected) {
                board.selectedPiece = unit;
            }
        }
    }

    public void PlaceUnit(int x, int y) {
        board.boardX = x;
        board.boardY = y;
        board.PlacePiece(board.tiles[x,y]);
    }
    // Detect mouse position in board
    public void Locate() {
        if(board.selectedPiece != null) {
            //PlaceUnit(x,y)
        }
    }

    public void TreeUpgrade()
    {
        int last = passiveTree.selectedNodes.Count - 1;
        Node lastNode = passiveTree.selectedNodes[last];
        if (lastNode.modifier.target == "Hero")
        {
            if (lastNode.modifier.method == "Absolute")
            {
                if (lastNode.modifier.key == "Damage")
                {
                    hero.damage += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Range")
                {
                    hero.range += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Attack Speed")
                {
                    hero.attackSpeed += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Life")
                {
                    hero.life += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Life Regen")
                {
                    hero.lifeRegen += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Armor")
                {
                    hero.armor += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Magic Resist")
                {
                    hero.magicResist += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Evade Chance")
                {
                    hero.evadeChance += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Crit Chance")
                {
                    hero.critChance += lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Crit Damage")
                {
                    hero.critDamage += lastNode.modifier.value;
                }
                // More can be added...
                else
                {

                }
            }
            else
            {
                if (lastNode.modifier.key == "Damage")
                {
                    hero.damage += hero.damage * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Range")
                {
                    hero.range += hero.range * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Attack Speed")
                {
                    hero.attackSpeed += hero.attackSpeed * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Life")
                {
                    hero.life += hero.life * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Life Regen")
                {
                    hero.lifeRegen += hero.lifeRegen * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Armor")
                {
                    hero.armor += hero.armor * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Magic Resist")
                {
                    hero.magicResist += hero.magicResist * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Evade Chance")
                {
                    hero.evadeChance += hero.evadeChance * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Crit Chance")
                {
                    hero.critChance += hero.critChance * lastNode.modifier.value;
                }
                else if (lastNode.modifier.key == "Crit Damage")
                {
                    hero.critDamage += hero.critDamage * lastNode.modifier.value;
                }
                // More can be added...
                else
                {

                }
            }

        }
        else if (lastNode.modifier.target == "Minions")
        {
            if (lastNode.modifier.method == "Absolute")
            {
                if (lastNode.modifier.key == "Damage")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.damage += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Range")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.range += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Attack Speed")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.attackSpeed += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.life += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life Regen")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.lifeRegen += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Armor")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.armor += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Magic Resist")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.magicResist += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Evade Chance")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.evadeChance += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Chance")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.critChance += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Damage")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.critDamage += lastNode.modifier.value;
                    }
                }
                // More can be added...
                else
                {

                }
            }
            else
            {
                if (lastNode.modifier.key == "Damage")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.damage += minion.damage * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Range")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.range += minion.range * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Attack Speed")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.attackSpeed += minion.attackSpeed * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.life += minion.life * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life Regen")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.lifeRegen += minion.lifeRegen * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Armor")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.armor += minion.armor * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Magic Resist")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.magicResist += minion.magicResist * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Evade Chance")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.evadeChance += minion.evadeChance * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Chance")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.critChance += minion.critChance * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Damage")
                {
                    foreach (Minion minion in minions)
                    {
                        minion.critDamage += minion.critDamage * lastNode.modifier.value;
                    }
                }
            }
        }
        else if (lastNode.modifier.target == "Units")
        {
            if (lastNode.modifier.method == "Absolute")
            {
                if (lastNode.modifier.key == "Damage")
                {
                    foreach (Unit unit in units)
                    {
                        unit.damage += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Range")
                {
                    foreach (Unit unit in units)
                    {
                        unit.range += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Attack Speed")
                {
                    foreach (Unit unit in units)
                    {
                        unit.attackSpeed += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life")
                {
                    foreach (Unit unit in units)
                    {
                        unit.life += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life Regen")
                {
                    foreach (Unit unit in units)
                    {
                        unit.lifeRegen += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Armor")
                {
                    foreach (Unit unit in units)
                    {
                        unit.armor += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Magic Resist")
                {
                    foreach (Unit unit in units)
                    {
                        unit.magicResist += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Evade Chance")
                {
                    foreach (Unit unit in units)
                    {
                        unit.evadeChance += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Chance")
                {
                    foreach (Unit unit in units)
                    {
                        unit.critChance += lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Damage")
                {
                    foreach (Unit unit in units)
                    {
                        unit.critDamage += lastNode.modifier.value;
                    }
                }
                // More can be added...
                else
                {

                }
            }
            else
            {
                if (lastNode.modifier.key == "Damage")
                {
                    foreach (Unit unit in units)
                    {
                        unit.damage += unit.damage * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Range")
                {
                    foreach (Unit unit in units)
                    {
                        unit.range += unit.range * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Attack Speed")
                {
                    foreach (Unit unit in units)
                    {
                        unit.attackSpeed += unit.attackSpeed * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life")
                {
                    foreach (Unit unit in units)
                    {
                        unit.life += unit.life * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Life Regen")
                {
                    foreach (Unit unit in units)
                    {
                        unit.lifeRegen += unit.lifeRegen * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Armor")
                {
                    foreach (Unit unit in units)
                    {
                        unit.armor += unit.armor * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Magic Resist")
                {
                    foreach (Unit unit in units)
                    {
                        unit.magicResist += unit.magicResist * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Evade Chance")
                {
                    foreach (Unit unit in units)
                    {
                        unit.evadeChance += unit.evadeChance * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Chance")
                {
                    foreach (Unit unit in units)
                    {
                        unit.critChance += unit.critChance * lastNode.modifier.value;
                    }
                }
                else if (lastNode.modifier.key == "Crit Damage")
                {
                    foreach (Unit unit in units)
                    {
                        unit.critDamage += unit.critDamage * lastNode.modifier.value;
                    }
                }
                // More can be added...
                else
                {

                }
            }
        }
        // For other types of nodes 
        else
        {

        }
    }

    public void ItemUpgrade()
    {
        Dictionary<string, float> keyValuePairs = new Dictionary<string, float>();
        foreach (Item item in hero.items)
        {
            if (item.rarity != Rarity.Unique)
            {
                foreach (Modifier modifier in item.itemModifiers)
                {
                    if (keyValuePairs.ContainsKey(modifier.key))
                    {
                        keyValuePairs[modifier.key] = keyValuePairs[modifier.key] + modifier.value;
                    }
                    else
                    {
                        keyValuePairs.Add(modifier.key, modifier.value);
                    }
                }
            }
            else
            {

            }
        }
        foreach (KeyValuePair<string, float> pair in keyValuePairs)
        {
            if (pair.Key == "Damage")
            {
                hero.damage = hero.damage + (hero.damage * (pair.Value / 100));
            }
            else if (pair.Key == "Range")
            {
                hero.range = hero.range + (hero.range * (pair.Value / 100));
            }
            else if (pair.Key == "Attack Speed")
            {
                hero.attackSpeed = hero.attackSpeed + (hero.attackSpeed * (pair.Value / 100));
            }
            else if (pair.Key == "Life")
            {
                hero.life = hero.life + (hero.life * (pair.Value / 100));
            }
            else if (pair.Key == "Life Regen")
            {
                hero.lifeRegen = hero.lifeRegen + (hero.lifeRegen * (pair.Value / 100));
            }
            else if (pair.Key == "Armor")
            {
                hero.armor = hero.armor + (hero.armor * (pair.Value / 100));
            }
            else if (pair.Key == "Magic Resist")
            {
                hero.magicResist = hero.magicResist + (hero.magicResist * (pair.Value / 100));
            }
            else if (pair.Key == "Evade Chance")
            {
                hero.evadeChance = hero.evadeChance + (hero.evadeChance * (pair.Value / 100));
            }
            else if (pair.Key == "Crit Chance")
            {
                hero.critChance = hero.critChance + (hero.critChance * (pair.Value / 100));
            }
            else
            {
                hero.critDamage = hero.critDamage + (hero.critDamage * (pair.Value / 100));
            }
        }
    }

    public void MatchBoards()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.tiles[i, j] = roundManager.board.tiles[i, j];
            }
        }
    }
}