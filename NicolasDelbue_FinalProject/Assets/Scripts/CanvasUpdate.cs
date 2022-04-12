using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasUpdate : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI foodAmount, heatAmount;
    
    void OnEnable()
    {
        RecourceScript.foodChange += UpdateFoodUI;
        RecourceScript.heatChange += UpdateHeatUI;
        UpdateHeatUI(RecourceScript.GetHeatAmount());
        UpdateFoodUI(RecourceScript.GetFoodAmount());
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
}
