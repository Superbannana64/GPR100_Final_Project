using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSourceTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Test");
            RecourceManager.SetIsHeat(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            bool local = false;
            Debug.Log("Test2");
            RecourceManager.SetIsHeat(local);
        }
    }
}
