using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManageEventSystem : MonoBehaviour
{
    public void ChangeScene(int num)
    {
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
