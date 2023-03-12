// Базовый класс атакующего здания

using UnityEngine;

public class DamageBuilding: Building
{
    public GameObject bulletPrefab;

    private DamageEntity _damageEntity;

    public DamageBuilding()
    {
        _damageEntity = new DamageEntity();
    }
    
    public void OnTriggerStay2D(Collider2D col)
    {
        if(!IsDropedBuilding)
            return;
        if (col == null || col.GetComponent<Solder>() == null)
            return;
       
        _damageEntity.Attack(bulletPrefab, col.gameObject, transform.gameObject);
    }
}