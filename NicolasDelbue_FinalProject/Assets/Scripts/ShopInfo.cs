using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    public bool isOpen = true;
    public int shopNum;
    public int entracne;
    //0 top
    //1 right
    //2 bottom
    //3 left
    public bool GetOpen()
    {
        return isOpen;
    }
    public int GetNum()
    {
        return shopNum;
    }
    public int GetEntrance()
    {
        return entracne;
    }
}
