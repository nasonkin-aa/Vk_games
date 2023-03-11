// Базовый класс солдата
using UnityEngine;
public class Solder: DamageEntity
{
    // Скорость солдата
    private int _speed = 10;

    // RigidBody объекта
    private Rigidbody2D _rigidbody;
    
    public void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var tempVector = new Vector2(1, 0).normalized * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + tempVector);
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        var obj = col.gameObject.GetComponent<Entity>();

        if (obj == null) return;
        
        Attack(obj);
    }
}