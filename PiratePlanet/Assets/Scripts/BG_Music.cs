using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Music : MonoBehaviour
{

    void Awake()
    {
        int NumberOfMusicPlayers = FindObjectsOfType<BG_Music>().Length;
        print("Music objects in scene " + NumberOfMusicPlayers);
        if (NumberOfMusicPlayers >= 2)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}
