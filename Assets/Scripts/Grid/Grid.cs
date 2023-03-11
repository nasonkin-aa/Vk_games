using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject tile;
    public int LengsHorizontal ;
    public int LengsVertical ;
    public Tile[,] Matrix;
    public void Start()
    {
        Matrix = new Tile[LengsHorizontal, LengsVertical];
        for (int i = 0; i < LengsHorizontal; i++)
            for(int j = 0; j < LengsVertical; j++)
            {
                Vector3 vector3 = new Vector3(
                    transform.position.x + tile.transform.localScale.x * 0.5f + i * tile.transform.localScale.x,
                    transform.position.y + tile.transform.localScale.y * 0.5f + j * tile.transform.localScale.y,
                    0);

                GameObject newT = Instantiate(tile, vector3, Quaternion.identity, transform);
                if (i > 2)
                    newT.GetComponent<Tile>().IsTileBlocked = true;
                Matrix[i,j] = newT.GetComponent<Tile>();
            }
        
    }
}
