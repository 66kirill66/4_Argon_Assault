using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //  что бы работать с текстом

public class ScoreBoard : MonoBehaviour {

    int score;
    Text scoreText;

	
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();      //ToString, чтобы изменить его с целого числа на строку.
    }
	
    public void ScoreHit(int scoreIncrease)
    {
        score = score + scoreIncrease;
        scoreText.text = "Score: " + score.ToString();
    }
	
}
