using System.Globalization;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{


    #region parameters
    
    [SerializeField] private float winOverTime = 100;
    [SerializeField] private float timeWhenWin = 1;
    [SerializeField] private TMP_Text scoreText;
    #endregion

    #region properties
    
    private float _elapsedTime = 0;
    private float _totalPoints;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(_elapsedTime >= timeWhenWin)
        {
            _elapsedTime = 0;
            _totalPoints += winOverTime;
            UpdateText();
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }
    }

    
    void UpdateText()
    {
        scoreText.text = _totalPoints.ToString(CultureInfo.CurrentCulture);
    }

    void AddScore(int points)
    {
        _totalPoints += points;
        UpdateText();
    }
}
