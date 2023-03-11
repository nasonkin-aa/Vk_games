// Базовый класс здания
public class Building : Entity
using UnityEngine;
{
    public int Size { get; set; }

    public void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
        print("Drag");
    }
    public void OnMouseDown()
    {
        print("down");
    }
    private void Update()
    {
       
    }

  

}
