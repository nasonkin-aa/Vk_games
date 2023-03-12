// Базовый класс здания
using UnityEngine;
public class Building : Entity
{
    public int Size { get; set; }
    public Collider2D Collider { get; set; }
    public bool IsDropedBuilding;
    public int Cost = 70;

    public delegate void Handler();
    public event Handler? TilsOnBlocked;

    public override void Death()
    {
        TilsOnBlocked?.Invoke();
        Destroy(transform.gameObject);
    }

    public void OnMouseUp()
    {
        if (IsDropedBuilding)
            return;

        if (Collider == null || Collider != null &&
            Collider.transform.GetComponent<Tile>() &&
            Collider.transform.GetComponent<Tile>().IsTileBlocked)
            {
                Destroy(transform.gameObject);
                return;
            }
        transform.GetComponent<BoxCollider2D>().isTrigger = false;
        TilsOnBlocked += Collider.transform.GetComponent<Tile>().UnBlock;
        transform.GetComponent<BoxCollider2D>().size = new Vector2(transform.localScale.x, transform.localScale.y);//
        transform.position = Collider.transform.position;//
        Collider.transform.GetComponent<Tile>().Building = transform.gameObject;
        Collider.transform.GetComponent<Tile>().IsTileBlocked = true;
        IsDropedBuilding = true;
        ColliderOn();
        Resurses.Money -= Cost;


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDropedBuilding)
            return;
        if (collision.GetComponent<Tile>() != null)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.white;
            Collider = collision;
            if ( Collider.transform.GetComponent<Tile>().IsTileBlocked)
            {
                transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Grid>() != null)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.white;
            Collider = null;  
        }
    }
    public virtual void ColliderOn()
    {
        return;
    }

    public void Update()
    {
        if (!IsDropedBuilding)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
    }

    public void FixedUpdate()
    {
        if (!IsDropedBuilding)
            return;
    }

}
