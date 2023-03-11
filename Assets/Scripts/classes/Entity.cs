using UnityEngine;

public class Entity: MonoBehaviour
{
    protected int hp;

    private void Death()
    {
        Destroy(transform.gameObject);
    }

    public void GetDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            Death();
        }
    }
}