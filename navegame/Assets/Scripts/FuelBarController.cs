
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelBarController : MonoBehaviour
{

    public static FuelBarController Instance ;
    [SerializeField] private float maxFuel;
    [SerializeField] private float remainingFuel;
    [SerializeField] private Vector2 innerBarProportions;
    
    [SerializeField] private LeaderBoard leaderBoard;
    [SerializeField] private GameObject innerBar;
    [SerializeField] private GameObject evilBar;
    [SerializeField] private int lowLifeThreshHold;

    private Image _innerImage;


    private float totalFuelConsumed;


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
        remainingFuel -= fuel;
        totalFuelConsumed += fuel;

        if (remainingFuel <= 0)
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
        //Descomentar cuando esté funcionando el leaderBoard
        
        leaderBoard.SumbitScoreRoutine(ScoreManager.Instance.GetScore());
        SceneManager.LoadScene("MenuPrincipal");

        Time.timeScale = 1.0f;  
    }

    void UpdateLowLifeBar()
    {
        evilBar.SetActive(remainingFuel <= lowLifeThreshHold);
    }
}
