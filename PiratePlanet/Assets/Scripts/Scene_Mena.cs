using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Mena : MonoBehaviour
{
    public string sceneName; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("LoadMainScene", 2.0f);
        }
    }
    void LoadMainScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
