using UnityEngine;

public class DamageEntity: Entity, IDamageEntity
{
    public int Damage { get; set; } = 1;
    
    public int AttackDistance { get; set; }

    public int AttackRate { get; set; } = 1;

    private double _nextDamageTime;
    
    public void Attack(IEntity entity)
    {
        if (_nextDamageTime > Time.time) return;
        
        entity.Hp -= Damage;
        _nextDamageTime = Time.time + AttackRate;
        print(entity.Hp);

        if (entity.Hp <= 0)
        {
            entity.Kill();
        }
    }
}