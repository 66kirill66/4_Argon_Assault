using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //  use text / ui

public class ScoreBoard : MonoBehaviour {

    int score;
    Text scoreText;

	
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();      //ToString, to change it from integer to string 
    }
	
    public void ScoreHit(int scoreIncrease)
    {
        score = score + scoreIncrease;
        scoreText.text = "Score: " + score.ToString();
    }
	
}
