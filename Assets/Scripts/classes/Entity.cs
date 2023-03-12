using UnityEngine;

public abstract class Entity: MonoBehaviour
{
    protected int hp = 10;

    public BasePlayer player;

    public virtual void Death()
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

    public void Awake()
    {
        player = BasePlayer.currPlayer;
        transform.gameObject.GetComponent<SpriteRenderer>().flipX = player.isReversed;
    }
}