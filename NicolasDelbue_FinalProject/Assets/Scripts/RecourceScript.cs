using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

static public class RecourceScript
{
    public static event Action<float> foodChange;
    public static event Action<float> heatChange;
    public static event Action<float> moneyChange;
    static private float foodAmount = 100;
    static private float heatAmount = 100;
    static private float healthAmount = 100;
    static private float moneyAmount = 3.00f;

    static public void SetFoodAmount(float food)
    {
        foodAmount = food;
        foodChange?.Invoke(foodAmount);
    }
    static public void SetHeatAmount(float heat)
    {
        heatAmount = heat;
        heatChange?.Invoke(heatAmount);
    }
    static public void SetHealthAmount(float health)
    {
        healthAmount = health;
    }
    static public void SetMoneyAmount(float money)
    {
        moneyAmount = money;
        moneyChange?.Invoke(moneyAmount);
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
    static public float GetMoneyAmount()
    {
        return moneyAmount;
    }
}
