using UnityEngine;

// Базовый класс здания
public class Building : MonoBehaviour, IEntity
{
    public int Hp {get; set;}
    
    public string Name { get; set; }
}
