using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasUpdate : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI foodAmount, heatAmount, healthAmount, moneyAmount;
    
    void OnEnable()
    {
        RecourceScript.foodChange += UpdateFoodUI;
        RecourceScript.heatChange += UpdateHeatUI;
        RecourceScript.moneyChange += UpdateMoneyUI;
        UpdateHeatUI(RecourceScript.GetHeatAmount());
        UpdateFoodUI(RecourceScript.GetFoodAmount());
        UpdateMoneyUI(RecourceScript.GetMoneyAmount());
    }
    void OnDisable()
    {
        RecourceScript.foodChange -= UpdateFoodUI;
    }
    void UpdateFoodUI(float foodNumToText) //Change to make it so it decreases a bar instead of output text
    {
        int local = (int)foodNumToText;
        foodAmount.text = ("Food: "+local.ToString());
    }
    void UpdateHeatUI(float heatNumToText)
    {
        int local = (int)heatNumToText;
        heatAmount.text = ("Heat: "+local.ToString());
    }
    void UpdateHealthUI(float healthNumToText)
    {
        int local = (int)healthNumToText;
        healthAmount.text = ("Health: "+local.ToString());
    }
    void UpdateMoneyUI(float moneyNumToText)
    {
        moneyAmount.text = ("Money: $"+moneyNumToText.ToString("#.00"));
    }
}
