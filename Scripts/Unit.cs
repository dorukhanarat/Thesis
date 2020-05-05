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
    public bool isVulnerable = true;
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
        if(isAlive) {
            Target();
            Move();
            Die();
        }

        if(target != null) {
            Attack();
        }

        if(target == null) {
            Idle();
        }
        
        if(unitSelected) {
            UnitClicked();
        }
        
        EnemyDead();
    }

    public IEnumerator Attack()
    {
        if ((Distance(target) <= range) && target.isAlive)
        {
            // Wait for some seconds..
            yield return new WaitForSeconds(attackSpeed / 1);
            target.TakeDamage(damage,"Physical");
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
            else {
                Idle();
            }
        }
    }

    // Detect clicks on unit need a trigger collider or something like that
    public void UnitClicked()
    {
        unitSelected = true;
    }

    public void EnemyDead()
    {
        if(!target.isAlive) {
            target = null;
            enemies.Remove(target);
        }                    
    }

    public void Idle() {

    }

    public void TakeDamage(float damage, string damageType) {
        if(isAlive && isVulnerable) {
            if(damageType == "Physical") {
                life -= ((damage) - (damage) * DamageReductionFunction(damageType));
        }
            else {
                life -= ((damage) - (damage) * DamageReductionFunction(damageType));
            }
        }  
    }

    //Needs a reduction calculation
    public float DamageReductionFunction(string damageType) {
        // some function with armor and magic resist

        if(damageType == "Physical") {
            return 0;
        }
        else {
            return 0;
        }
    }

}
