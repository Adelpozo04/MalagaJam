
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FuelBarController : MonoBehaviour
{

    public static FuelBarController Instance ;
    public GameObject visualContaierGameOver;
    public GameObject visualContaierWarningChange;

    [SerializeField] private float maxFuel;
    [SerializeField] private float remainingFuel;
    [SerializeField] private Vector2 innerBarProportions;
    
    [SerializeField] private LeaderBoard leaderBoard;
    [SerializeField] private GameObject innerBar;
    [SerializeField] private GameObject evilBar;
    [SerializeField] private int lowLifeThreshHold;

    private Image _innerImage;


    private float totalFuelConsumed;

    bool corrutinaStarted = false;  

    public float getFuelConsumed()
    {
        return totalFuelConsumed;
    }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        //Inicializa la barra interior al tamaño y la posición adecuada
        _innerImage = innerBar.GetComponent<Image>();
        RestartFuelBar();
    }
    
    public void AddFuel(float fuel)
    {
        remainingFuel += fuel;
        if (remainingFuel >= maxFuel)
        {
            remainingFuel = maxFuel;
        }
        UpdateBar();
    }

    public void SubstractFuel(float fuel)
    {

        if (fuel < 0) { 
            //print("maaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaal"); 
            fuel*=-1;   
        }
        remainingFuel -= fuel;
        totalFuelConsumed += fuel;

        if (remainingFuel <= 0 && !corrutinaStarted)
        {
            GameOver();
        }
        UpdateBar();
    }
    
    public void RestartFuelBar()
    {
        remainingFuel = maxFuel;
        totalFuelConsumed = 0;
        UpdateBar();
    }

    private void UpdateBar()
    {
        _innerImage.fillAmount = (float) remainingFuel / maxFuel;
        UpdateLowLifeBar();
    }

    void GameOver()
    {
    
        StartCoroutine(goToGameOver());

    }
    
 

    public void goMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    void UpdateLowLifeBar()
    {
        evilBar.SetActive(remainingFuel <= lowLifeThreshHold);
    }



    IEnumerator goToGameOver()
    {
        corrutinaStarted = true;     


        visualContaierGameOver.SetActive(true);


        Time.timeScale = 0.0f;

        leaderBoard.SumbitScoreRoutine(ScoreManager.Instance.GetScore());

        yield return new WaitForSecondsRealtime(0.05f);
        visualContaierWarningChange.SetActive(false);

        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("GameOver");

        Time.timeScale = 1.0f;


    }
}
