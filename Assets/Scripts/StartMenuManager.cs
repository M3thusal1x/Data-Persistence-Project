using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class StartMenuManager : MonoBehaviour
{
    private GameObject inputField; 

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.Load();
        inputField = GameObject.FindGameObjectWithTag("NameInput");
        TMP_InputField textField = inputField.GetComponent<TMP_InputField>();
        textField.text = DataManager.Instance.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string playerName)
    {
        DataManager.Instance.PlayerName = playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
