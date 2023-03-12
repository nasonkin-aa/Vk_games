using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
                var isDisabledFields = BasePlayer.currPlayer.position == PlayerPosition.Right ? i < LengsHorizontal - 3 : i > 2;
                
                if (isDisabledFields)
                    newT.GetComponent<Tile>().IsTileBlocked = true;
                    newT.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                Matrix[i,j] = newT.GetComponent<Tile>();
            }
        
    }
}
