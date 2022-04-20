using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class SceneManage
{
    static public void ChangeScene(int num)
    {
        SceneManager.LoadScene(num);
    }
    static public void NewGameScene(int num)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(num);
    }
    static public void FullQuit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    static public int GetSceneNum()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
