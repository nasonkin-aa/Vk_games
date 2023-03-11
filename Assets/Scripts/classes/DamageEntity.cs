using UnityEngine;

public class DamageEntity: Entity
{
    public int damage = 1;

    public int attackDistance = 1;

    public int attackRate = 1;

    private double _nextDamageTime;

    protected void Attack(Entity entity)
    {
        if (_nextDamageTime > Time.time) return;
        
        entity.GetDamage(damage);
        _nextDamageTime = Time.time + attackRate;
    }
}