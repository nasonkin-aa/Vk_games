using UnityEngine;

public class DamageEntity: Entity
{
    protected int damage = 1;

    protected int attackDistance;

    protected int attackRate = 1;

    private double _nextDamageTime;
    
    protected void Attack(Entity entity)
    {
        if (_nextDamageTime > Time.time) return;
        
        entity.GetDamage(damage);
        _nextDamageTime = Time.time + attackRate;
    }
}