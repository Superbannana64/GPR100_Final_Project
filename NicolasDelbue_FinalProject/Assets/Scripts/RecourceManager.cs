using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceManager : MonoBehaviour
{
    static private bool isHeat = false, notHungry = false; //Should get from other scripts;
    private bool justAte = false;
    private float localHeat, localHungry;
    public float foodChange, heatChange, heatUp;

    // Start is called before the first frame update
    void Start()
    {
        isHeat = false;
        notHungry = false;
    }

    // Update is called once per frame
    void Update()
    {
        HeatManagement();
        FoodManagement();
    }
    void AteFood(float foodNum)
    {
        localHungry = RecourceScript.GetFoodAmount();
        localHungry += foodNum;
        if(localHungry > 100)
        {
            localHungry = 100;
        }
        justAte = true;
        notHungry = true;
        RecourceScript.SetFoodAmount(localHungry);
    }
    IEnumerator StillNotHungry()
    {
        notHungry = false;
        yield return new WaitForSeconds(10);
        justAte = false;
    }
    void FoodManagement()
    {
        localHungry = RecourceScript.GetFoodAmount();
        if(notHungry && justAte) //This runs after you eat some food so you dont immediately lose food after eating
        {
            StartCoroutine(StillNotHungry());//Theoretically will wait for 10 seconds before hunger goes down
        }
        else if(!notHungry && !justAte)
        {
            localHungry -= foodChange;
            if(localHungry < 0)
            {
                localHungry = 0;
            }
        }
        else
        {
            Debug.Log("Else in FoodManagement"); //This will happen as the coroutine will still be running while after the first if statement
        }
        RecourceScript.SetFoodAmount(localHungry);
    }
    void HeatManagement()
    {
        localHeat = RecourceScript.GetHeatAmount();
        if(isHeat)//If player is near heat source
        {
            localHeat += heatUp;
            if(localHeat > 100) //Local heat increases by 2 until 100
            {
                localHeat = 100;
            }
        }
        else if(!isHeat)//If player is not near heat
        {
            localHeat -= heatChange; //Heat will slowly go down over time
            if(localHeat < 0) //If heat at 0 will stay at 0
            {
                localHeat = 0;
            }
        }
        else
        {
            Debug.Log("Else in HeatManagement");//Should never get here
        }
        RecourceScript.SetHeatAmount(localHeat);
        //canvas update (maybe done in canvas update)
    }
    static public void SetIsHeat(bool heat)
    {
        isHeat = heat;
    }
    static public void SetNotHungry(bool hunger)
    {
        notHungry = hunger;
    }
}
