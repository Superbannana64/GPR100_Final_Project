using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

static public class RecourceScript
{
    public static event Action<float> foodChange;
    public static event Action<float> heatChange;
    public static event Action<float> moneyChange;
    public static event Action<float> healthChange;
    static private float foodAmount = 100f;
    static private float heatAmount = 100f;
    static private float healthAmount = 100f;
    static private float moneyAmount = 3.00f;
    static private bool niceCloths = false;
    static private bool suitOwn = false;
    static private bool appartmentOwn = false;
    static public void SetAppartmentOwn(bool aps)
    {
        appartmentOwn = aps;
    }
    static public bool GetAppartmentOwn()
    {
        return appartmentOwn;
    }
    static public void ResetRecource()
    {
        foodAmount = 100;
        heatAmount = 100;
        healthAmount = 100;
        moneyAmount = 3.00f;
        niceCloths = false;
        suitOwn = false;
        appartmentOwn = false;
    }
    static public void SetNiceCloths(bool cloths)
    {
        niceCloths = cloths;
    }
    static public void SetSuitOwn(bool cloths)
    {
        suitOwn = cloths;
    }
    static public bool GetNiceCloths()
    {
        return niceCloths;
    }
    static public bool GetSuitOwn()
    {
        return suitOwn;
    }
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
        healthChange?.Invoke(healthAmount);
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
