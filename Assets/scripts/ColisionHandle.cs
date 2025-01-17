﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class ColisionHandle : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float LevelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", LevelLoadDelay);
    }
    private void StartDeathSequence()
    {       
        SendMessage("OnPlayerDeath");   // string link. 
    }
    private void ReloadScene()   
    {
        SceneManager.LoadScene(1);
    }
}
