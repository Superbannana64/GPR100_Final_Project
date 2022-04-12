using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyObjectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject EventSys;
    public float objCost, foodAmountRefil;
    bool CanBuy = false;
    void Update()
    {
        if(CanBuy)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                BuyObject();
            }
        }
    }
    void BuyObject()
    {
        if(objCost > RecourceScript.GetMoneyAmount())
        {
            //Cant buy Show Text That Cant Buy
        }
        else
        {
            RecourceScript.SetMoneyAmount(RecourceScript.GetMoneyAmount()-objCost);
            EventSys.GetComponent<RecourceManager>().AteFood(foodAmountRefil);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered Item Range");
        if(col.CompareTag("Player"))
        {
            CanBuy = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        CanBuy = false;
    }
}