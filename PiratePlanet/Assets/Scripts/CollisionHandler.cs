using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
        [Tooltip("in seconds")] [SerializeField] float delayOnLevels = 2f;
        [Tooltip("Player FX prefab")] [SerializeField] GameObject deathFX;

         void OnTriggerEnter(Collider other)
        {
            StartDeathSequence();
        }
    

    private void StartDeathSequence()
    {
        // stash ss
        print("Ship trigger Enter");
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("LoadFirstLevel", delayOnLevels);
    }
    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    

}
