using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string userName;
    public string topScoreUserName;
    public int topScore;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null) {
            Destroy(instance);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
