// Базовый класс здания
using UnityEngine;
public class Building : Entity
{
    public int Size { get; set; }
    public Collider2D Collider { get; set; }
    public bool IsDropedBuilding;
    public int Cost = 70;

    
    /*    public void OnMouseDrag()
        {
            if (IsDropedBuilding) 
                return; 

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
            print("Drag");
        }*/

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
        //ColliderOn();
        transform.GetComponent<BoxCollider2D>().size = new Vector2(transform.localScale.x, transform.localScale.y);//
        transform.position = Collider.transform.position;//
        Collider.transform.GetComponent<Tile>().Building = transform.gameObject;
        Collider.transform.GetComponent<Tile>().IsTileBlocked = true;
        this.IsDropedBuilding = true;
        Resurses.Money -= Cost;


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("entre");
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

    public void Update()
    {
        if (!IsDropedBuilding)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
    }
    public virtual void ColliderOn()
    {
        return;
    }

}
