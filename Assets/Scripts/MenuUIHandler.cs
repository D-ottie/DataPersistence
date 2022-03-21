using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField userInput;
    public string playerName;
    public static MenuUIHandler Instance;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InputYourName()
    {
        playerName = userInput.text;
    }

    public void StartMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        FindObjectOfType<MainManager>().SaveHighScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

        #else
        Application.Quit();

        #endif
    }

 
}
