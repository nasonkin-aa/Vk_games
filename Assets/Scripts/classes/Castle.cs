using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Building
{
    public GameObject win;
    public GameObject los;
    public void Awake()
    {
        IsDropedBuilding = true;
    }
    private void OnDestroy()
    {
        if (gameObject.GetComponent<Entity>().IsPlayer == true)
        {
            los.SetActive(true);
        }
        else
        {
            win.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}
