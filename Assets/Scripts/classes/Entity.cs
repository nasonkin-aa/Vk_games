using UnityEngine;

public class Entity: MonoBehaviour, IEntity
{
    public int Hp { get; set; }
    
    public string Name { get; set; }
    
    public void Kill()
    {
        Destroy(transform.gameObject);
    }
}