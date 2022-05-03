using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyObjectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject EventSys;
    public float objCost, foodAmountRefil;
    private bool CanBuy = false;
    public bool needGoodCloths = false, needSuit = false;
    public AudioSource As;
    void Update()
    {
        if(!needGoodCloths && !needSuit)
        {
            if(CanBuy)
            {
                if(Input.GetKeyUp(KeyCode.E))
                {
                    BuyObject();
                }
            }
        }
        else if(needGoodCloths)
        {
            if(CanBuy && RecourceScript.GetNiceCloths())
            {
                if(Input.GetKeyUp(KeyCode.E))
                {
                    BuyObject();
                }
            }
        }
        else if(needSuit)
        {
            if(CanBuy && RecourceScript.GetSuitOwn())
            {
                if(Input.GetKeyUp(KeyCode.E))
                {
                    BuyObject();
                }
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
            As.Play();
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