using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    [SerializeField] public float damage;
    [SerializeField] public float range;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float life;
    [SerializeField] public float lifeRegen;
    [SerializeField] public float armor;
    [SerializeField] public float magicResist;
    [SerializeField] public float evadeChance;
    [SerializeField] public float critChance;
    [SerializeField] public float critDamage;
    public bool unitSelected = false;
    public bool isAlive = true;
    public List<Unit> enemies = new List<Unit>();
    public Unit target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Target();
        Move();
        Attack();
        Die();
        UnitClicked();
        EnemyDead();
    }

    IEnumerator Attack()
    {
        if ((Distance(target) <= range) && target.isAlive)
        {
            // Wait for some seconds..
            yield return new WaitForSeconds(attackSpeed / 1);
            target.life -= damage;
        }
        yield return null;
        StartCoroutine(Attack());
    }

    public void Die()
    {
        if (life <= 0)
        {
            isAlive = false;
        }
    }

    // Modify distance method

    public float Distance(Unit unit)
    {
        // Needs modification to 2d distance or not
        var dist = Vector3.Distance(transform.position, unit.transform.position);
        return dist;
    }
    // unit position to target position
    // Needs Delta time for attribute for flow
    public void Move()
    {
        var direction = (target.transform.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
        if (Distance(target) > range)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 3f * Time.deltaTime);
        }
    }

    public void Target()
    {
        if (target == null)
        {
            if (enemies.Count > 0)
            {
                target = enemies[0];
                foreach (Unit unit in enemies)
                {
                    if (unit.isAlive)
                    {
                        if (Distance(target) > Distance(unit))
                        {
                            target = unit;
                        }
                    }
                }
            }
        }
    }
    // Detect clicks on unit
    public void UnitClicked()
    {
        unitSelected = true;
    }

    public void EnemyDead()
    {
        if (enemies.Count > 0)
        {
            foreach (Unit unit in enemies)
            {
                if (unit.isAlive == false)
                {
                    target = null;
                    enemies.Remove(unit);
                }
            }
        }
    }

}
