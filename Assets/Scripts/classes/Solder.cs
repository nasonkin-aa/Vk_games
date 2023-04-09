// Базовый класс солдата
using UnityEngine;
public class Solder: DamageEntity
{
    // Скорость солдата
    protected int _speed = 10;
    // RigidBody объекта
    private Rigidbody2D _rigidbody;

    public int Vertical = 1;

    private bool IsCombat = false;
    public Sprite dog;
    public Sprite Rat;
    public void Start()
    {
        hp = 10;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if (IsCombat)
            return;
        if (transform.gameObject.GetComponent<Entity>().IsPlayer == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = Rat;

            var tempVector = new Vector2(Vertical * -1, 0).normalized * (_speed * Time.deltaTime);
            _rigidbody.MovePosition(_rigidbody.position + tempVector * 0.2f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = dog;
            var tempVector = new Vector2(Vertical, 0).normalized * (_speed * Time.deltaTime);
            _rigidbody.MovePosition(_rigidbody.position + tempVector * 0.2f);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Bullet>() != null)
        {
            Debug.Log(col.gameObject.GetComponent<Bullet>() is Bullet);
            return;
        }

        if (gameObject.GetComponent<Entity>().IsPlayer && col.gameObject.GetComponent<Entity>().IsPlayer ||
            !gameObject.GetComponent<Entity>().IsPlayer && !col.gameObject.GetComponent<Entity>().IsPlayer)
            return;

        if (col is BoxCollider2D)
        {
            
            IsCombat = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<Entity>();
        //print(obj);
        if (obj == null) return;
        Attack(obj);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            return;
        }
        IsCombat = false;
    }
}