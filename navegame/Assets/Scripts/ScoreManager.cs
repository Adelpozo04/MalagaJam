using System;
using System.Globalization;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    
    #region parameters
    
    [SerializeField] private int winOverTime = 100;
    [SerializeField] private int timeWhenWin = 1;
    [SerializeField] private TMP_Text scoreText;
    
    #endregion

    #region properties

    private SizeChangeAnim scAnim;
    private float _elapsedTime;
    private int _totalPoints;
    #endregion

    static private ScoreManager instance;
    static public ScoreManager Instance { get { return instance; } }


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scAnim = GetComponent<SizeChangeAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_elapsedTime >= timeWhenWin)
        {
            _elapsedTime = 0;
            AddScore(winOverTime);
            UpdateText();
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }
    }

    
    private void UpdateText()
    {
        scoreText.text = _totalPoints.ToString(CultureInfo.CurrentCulture);
    }

    public void AddScore(int points)
    {
        _totalPoints += points;
        scAnim.DoIt();
        UpdateText();
    }

    public int GetScore()
    {
        return _totalPoints;
    }
}
