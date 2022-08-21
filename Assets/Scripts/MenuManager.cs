using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI topScoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadTopScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadTopScore()
    {
        string saveFilePath = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(saveFilePath))
        {
            string jsonResult = File.ReadAllText(saveFilePath);

            PlayerData savePlayerData = JsonUtility.FromJson<PlayerData>(jsonResult);
            GameManager.instance.topScoreUserName = savePlayerData.topUserName;
            GameManager.instance.topScore = savePlayerData.topScore;

            topScoreText.text = "Best Score: " + GameManager.instance.topScoreUserName + ": " + GameManager.instance.topScore;
        }
    }

    public void TransferUserName()
    {
        GameManager.instance.userName = userNameText.text;

        Debug.Log(GameManager.instance.userName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();  
#endif

    }
}
