using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class RecourceScript
{
    static private float foodAmount;
    static private float heatAmount;
    static private float healthAmount;

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
    //Make Some Getters for Canvas UI;
}
