
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelBarController : MonoBehaviour
{

    public static FuelBarController Instance ;


    [SerializeField] private float maxFuel;
    [SerializeField] private float remainingFuel;
    [SerializeField] private Vector2 innerBarProportions;
    
    [SerializeField] private LeaderBoard leaderBoard_;
    [SerializeField] private GameObject _innerBar;
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
        _innerImage = _innerBar.GetComponent<Image>();
        RestartFuelBar();
    }
    /*
    private void Update()
    {
        print(remainingFuel);
    }
     */
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
    }

    void GameOver()
    {
        //Descomentar cuando esté funcionando el leaderBoard
        
        leaderBoard_.SumbitScoreRoutine(ScoreManager.Instance.GetScore());
        SceneManager.LoadScene("MenuPrincipal");

        Time.timeScale = 1.0f;  
    }
}
