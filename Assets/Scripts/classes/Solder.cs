// Базовый класс солдата
using UnityEngine;
public class Solder: DamageEntity
{
    // Скорость солдата
    protected int _speed = 10;
    // RigidBody объекта
    private Rigidbody2D _rigidbody;

    public bool IsCombat; 
    
    public void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if (IsCombat)
            return;
        var tempVector = new Vector2(1, 0).normalized * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + tempVector * 0.2f);
    }

  
    public void OnCollisionEnter2D(Collision2D col)
    {
        IsCombat = true;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        var obj = collision.gameObject.GetComponent<Entity>();
        print(obj);
        if (obj == null) return;
        Attack(obj);
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        IsCombat = false;
    }
}