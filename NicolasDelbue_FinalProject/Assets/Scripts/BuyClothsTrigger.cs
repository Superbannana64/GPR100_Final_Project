using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyClothsTrigger : MonoBehaviour
{
    public float objCost;
    private bool CanBuy = false;
    public bool needGoodCloths = false, needSuit = false;
    void Update()
    {
        if(needGoodCloths)
        {
            if(CanBuy)
            {
                if(Input.GetKeyUp(KeyCode.E))
                {
                    BuyObjectNiceCloths();
                }
            }
        }
        else if(needSuit)
        {
            if(CanBuy)
            {
                if(Input.GetKeyUp(KeyCode.E))
                {
                    BuyObjectSuit();
                }
            }
        }
        
    }
    void BuyObjectNiceCloths()
    {
        if(objCost > RecourceScript.GetMoneyAmount())
        {
            //Cant buy Show Text That Cant Buy
        }
        else
        {
            RecourceScript.SetMoneyAmount(RecourceScript.GetMoneyAmount()-objCost);
            RecourceScript.SetNiceCloths(true);
        }
    }
    void BuyObjectSuit()
    {
        if(objCost > RecourceScript.GetMoneyAmount())
        {
            //Cant buy Show Text That Cant Buy
        }
        else
        {
            RecourceScript.SetMoneyAmount(RecourceScript.GetMoneyAmount()-objCost);
            RecourceScript.SetSuitOwn(true);
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
