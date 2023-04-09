using UnityEngine;

public class Bullet: MonoBehaviour
{
    private int _speed = 40;

    private GameObject _parent;

    private int _damage;

    private Rigidbody2D _rigidbody;

    private Vector2 _finalPos;

    public bool isPlayer;
    public void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        //Destroy(transform.gameObject, 20);
    }

    public void Init(GameObject parent, int damage, Vector2 finalPos)
    {
        isPlayer = parent.GetComponent<Entity>().IsPlayer;
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.GetComponent<Solder>() == null)
            return;
        Entity entity = col.gameObject.GetComponent<Entity>();
        if (isPlayer && !entity.IsPlayer ||
            !isPlayer && entity.IsPlayer)
        {
            entity.GetDamage(_damage);
            Destroy(transform.gameObject);
        }

        //if (entity == null || col.gameObject.Equals(_parent)) return;

        Destroy(transform.gameObject, 3f);
        return;
    }
}