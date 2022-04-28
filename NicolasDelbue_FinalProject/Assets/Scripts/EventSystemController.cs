using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemController : MonoBehaviour
{
    bool test = false;
    public bool noEsc;
    [SerializeField] private Canvas EscMenu;
    // Start is called before the first frame update
    void Start()
    {
        if(!noEsc)
        {
            EscMenu.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!noEsc)
        {
            if(test)
            {
                Time.timeScale = 0;
                EscMenu.gameObject.SetActive(true);
            
            }
            else if(!test)
            {
                Time.timeScale = 1;
                EscMenu.gameObject.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Timer.TimerSwitch();
                RecourceManager.UpdateFoodSwitch();
                test = !test;
            }
        }
        if(RecourceScript.GetSuitOwn() && Timer.GetDay() == 2)
        {
            Debug.Log("YouWin");
            ChangeSceneLeaveLevel(0);
        }
    }

    //For Buttons
    public void ChangeScene(int num)
    {
        SceneManage.ChangeScene(num);
    }
    public void ChangeSceneLeaveLevel(int num)
    {
        test = true;
        Timer.SetTimer(true);
        RecourceManager.SetFoodSwitch(true);
        SceneManage.ChangeScene(num);
    }
    public void NewGameScene(int num)
    {
        PlayerPrefs.DeleteAll();
        Timer.ResetTimer();
        RecourceScript.ResetRecource();
        SceneManage.ChangeScene(num);
    }
    public void FullQuit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
