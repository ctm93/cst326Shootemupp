using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text hiscoreText;
    public int scorePoints = 0;
    public int highscore = 0;


    void OnCollisionEnter2D(Collision2D collision)
    {


        
            Destroy(gameObject);
            scorePoints = scorePoints + 100;
            highscore = scorePoints;
            scoreText.text = scorePoints.ToString("0000");
            hiscoreText.text = highscore.ToString("0000");


    }
}
