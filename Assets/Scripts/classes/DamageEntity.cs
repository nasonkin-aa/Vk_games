using UnityEngine;

public class DamageEntity: Entity
{
    public int damage = 2;

    public int attackDistance = 1;

    public int attackRate = 1;

    private double _nextDamageTime;

    private bool IsAttackDisabled => _nextDamageTime > Time.time;

    public void Attack(Entity entity)
    {
        if (IsAttackDisabled) return;
        if (gameObject.GetComponent<Entity>().IsPlayer && entity.GetComponent<Entity>().IsPlayer ||
            !gameObject.GetComponent<Entity>().IsPlayer && !entity.GetComponent<Entity>().IsPlayer)
            return;
        entity.GetDamage(damage);
        
        _nextDamageTime = Time.time + attackRate;
    }

    public void Attack(GameObject bullet, GameObject targetEntity, GameObject parent)
    {
        if (IsAttackDisabled) return;

        GameObject bulletInstance = Instantiate(bullet, parent.transform.position, Quaternion.identity);
        bulletInstance.gameObject.GetComponent<Bullet>().Init(
            parent, 
            damage, 
            targetEntity.transform.position);

        _nextDamageTime = Time.time + attackRate;
    }
}