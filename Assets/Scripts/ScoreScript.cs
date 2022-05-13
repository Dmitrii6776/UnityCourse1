using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private int scorePerHit = 10;
    private int score = 0;
    private Text _scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = score.ToString();
    }

    // Update is called once per frame
    public void ScoreHit()
    {
        _scoreText = GetComponent<Text>();
        score += scorePerHit;
        _scoreText.text = score.ToString();
    }
}
