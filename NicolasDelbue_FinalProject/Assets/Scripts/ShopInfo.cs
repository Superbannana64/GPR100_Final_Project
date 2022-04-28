using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    public bool isOpen = true;
    public int shopNum;
    public bool GetOpen()
    {
        return isOpen;
    }
    public int GetNum()
    {
        return shopNum;
    }
}
