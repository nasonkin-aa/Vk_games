using UnityEngine;

public class Bullet: MonoBehaviour
{
    private int _speed = 100;

    private GameObject _parent;

    private int _damage;

    private Rigidbody2D _rigidbody;

    private Vector2 _finalPos;

    public void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        Destroy(transform.gameObject, 20);
    }

    public void Init(GameObject parent, int damage, Vector2 finalPos)
    {
        _parent = parent;
        _damage = damage;
        _finalPos = finalPos;
    }

    public void Update()
    {
        Vector2 pos = Vector2.MoveTowards(
            transform.position, 
            _finalPos, 
            Time.deltaTime * _speed
            );
        
        _rigidbody.MovePosition(pos);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Entity entity = col.gameObject.GetComponent<Entity>();
        
        print(col.gameObject.Equals(_parent));
        
        if (entity == null || col.gameObject.Equals(_parent)) return;

        entity.GetDamage(_damage);
        Destroy(transform.gameObject);
    }
}