using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    
    void Update()
    {
        if (!IsOwner)
            return;
        if (GameManager.Instance.IsGamePlaying())
            InputPlayer();
    }
    void InputPlayer()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(inputHorizontal * 4, inputVertical * 4);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity =  new Vector2(0,0);
        }
    }
}
