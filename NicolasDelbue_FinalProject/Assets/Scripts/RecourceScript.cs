using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class RecourceScript
{
    static private float foodAmount = 100;
    static private float heatAmount = 100;
    static private float healthAmount = 100;

    static public void SetFoodAmount(float food)
    {
        foodAmount = food;
    }
    static public void SetHeatAmount(float heat)
    {
        heatAmount = heat;
    }
    static public void SetHealthAmount(float health)
    {
        healthAmount = health;
    }
    static public float GetFoodAmount()
    {
        return foodAmount;
    }
    static public float GetHeatAmount()
    {
        return heatAmount;
    }
    static public float GetHealthAmount()
    {
        return healthAmount;
    }
}
