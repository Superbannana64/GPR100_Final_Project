using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceManager : MonoBehaviour
{
    static private bool isHeat = false, notHungry = false, UpdateFood = true; //Should get from other scripts;
    private bool justAte = false;
    private float localHeat, localHungry, localHealth;
    public float foodChange, heatChange, heatUp;

    static public void UpdateFoodSwitch()
    {
        UpdateFood = !UpdateFood;
    }
    static public void SetFoodSwitch(bool food)
    {
        UpdateFood = food;
    }
    // Start is called before the first frame update
    void Start()
    {
        isHeat = false;
        notHungry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UpdateFood)
        {
            HeatManagement();
            FoodManagement();
            HealthManagement();
        }
    }
    public void AteFood(float foodNum)
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
            Debug.Log("Should only run once");
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
            //This will happen as the coroutine will still be running while after the first if statement
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
    void HealthManagement()
    {

        if(localHeat <= 0 && localHungry > 0)
        {
            //Decrease health at a rate
        }
        else if(localHeat > 0 && localHungry <= 0)
        {
            //Decrease health as rate above
        }
        else if(localHeat <= 0 && localHungry <= 0)
        {
            //Decrease health at double the rate
        }
        else
        {
            //Not Decreasing Health
        }
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
