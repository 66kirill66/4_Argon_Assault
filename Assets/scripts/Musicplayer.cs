using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Musicplayer : MonoBehaviour {

    private void Awake()
    {                                                       
        int numMusicPlayers = FindObjectsOfType<Musicplayer>().Length;
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
