using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

    public void StartRealGame()
    {
        SceneManager.LoadScene(2);
    }

    //public void SaveCardClicked()
    //{
    //    MainManager.Instance.SaveCards();
    //}

    //public void LoadCardClicked()
    //{
    //    MainManager.Instance.LoadCards();
    //}
}
