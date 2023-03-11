using System;
using UnityEngine;

public class TestTower : DamageBuilding
{
    public GameObject bullet;
    
    private double _nextDamageTime;
    
    public void OnTriggerStay2D(Collider2D col)
    {
        if (_nextDamageTime > Time.time) return;
        
        _nextDamageTime = Time.time + damageEntity.attackRate;
        var bull = Instantiate(bullet, transform.position, Quaternion.identity);
        bull.GetComponent<Bullet>().Init(gameObject, damageEntity.damage, col.transform.position);
    }
}