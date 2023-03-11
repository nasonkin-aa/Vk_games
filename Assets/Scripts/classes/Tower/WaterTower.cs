using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTower : Tower
{
    public GameObject bullet;

    private double _nextDamageTime;

    public void OnTriggerStay2D(Collider2D col)
    {
        if(!IsDropedBuilding)
            return;
        if (col == null || col.GetComponent<Solder>() == null)
            return;
        if (_nextDamageTime > Time.time) return;

        _nextDamageTime = Time.time + damageEntity.attackRate;
        var bull = Instantiate(bullet, transform.position, Quaternion.identity);
        bull.GetComponent<Bullet>().Init(gameObject, damageEntity.damage, col.transform.position);
    }
}
