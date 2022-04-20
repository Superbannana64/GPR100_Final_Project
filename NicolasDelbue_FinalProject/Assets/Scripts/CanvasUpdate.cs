using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class CanvasUpdate : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI foodAmount, heatAmount, healthAmount, moneyAmount, timerAmount, dayNum;
    [SerializeField] private string textFormat;
    //Reminder, Make Food, Heat, And Health into bars that decrease
    void OnEnable()
    {
        RecourceScript.foodChange += UpdateFoodUI;
        RecourceScript.heatChange += UpdateHeatUI;
        RecourceScript.moneyChange += UpdateMoneyUI;
        Timer.timerChange+=UpdateTimerUI;
        Timer.dayChange+=UpdateDayUI;
        UpdateHeatUI(RecourceScript.GetHeatAmount());
        UpdateFoodUI(RecourceScript.GetFoodAmount());
        UpdateMoneyUI(RecourceScript.GetMoneyAmount());
    }
    void OnDisable()
    {
        RecourceScript.foodChange -= UpdateFoodUI;
        RecourceScript.heatChange -= UpdateHeatUI;
        RecourceScript.moneyChange -= UpdateMoneyUI;
        Timer.timerChange-=UpdateTimerUI;
        Timer.dayChange-=UpdateDayUI;
    }
    void UpdateDayUI(int day)
    {
        dayNum.text = ("Day: "+day.ToString());
    }
    void UpdateTimerUI(double timerNum)
    {
        TimeSpan time = TimeSpan.FromMinutes(timerNum);

        if(time.Seconds < 10)
        {
            timerAmount.text = "Clock: " + textFormat/*in inspector*/ + time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        }
        else
        {
            timerAmount.text = "Clock: " + textFormat/*in inspector*/ + time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
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
