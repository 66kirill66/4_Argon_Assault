using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Musicplayer : MonoBehaviour {



    private void Awake()
    {                                                        // длина
        int numMusicPlayers = FindObjectsOfType<Musicplayer>().Length; //<>чтобы указать музыкальный проигрыватель в качестве типа.
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        } 
    }

   
}
