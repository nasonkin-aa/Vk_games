// Базовый класс атакующего здания

using UnityEngine;

public class DamageBuilding: Building
{
    public GameObject bulletPrefab;

    protected DamageEntity damageEntity;

    public DamageBuilding()
    {
        damageEntity = new DamageEntity();
    }
    
    public void OnTriggerStay2D(Collider2D col)
    {
        if(!IsDropedBuilding)
            return;
        if (col == null)
            return;
        if (col.transform.GetComponent<Solder>() == null)
            return;

        print(bulletPrefab);
        print(col.gameObject);
        print(transform.gameObject);
        damageEntity.Attack(bulletPrefab, col.gameObject, transform.gameObject);
    }
}