
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    [SerializeField] private float maxFuel;
    [SerializeField] private float remainingFuel;
    [SerializeField] private Vector2 innerBarProportions;
    
    [SerializeField] private GameObject _innerBar;
    private Image _innerImage;


    private float totalFuelConsumed;


    public float getFuelConsumed()
    {
        return totalFuelConsumed;
    }

    void Start()
    {
        //Inicializa la barra interior al tamaño y la posición adecuada
        _innerImage = _innerBar.GetComponent<Image>();
        RestartFuelBar();
    }

    public void AddFuel(int fuel)
    {
        remainingFuel += fuel;
        if (remainingFuel >= maxFuel)
        {
            remainingFuel = maxFuel;
        }
        UpdateBar();
    }

    public void SubstractFuel(int fuel)
    {
        remainingFuel -= fuel;
        totalFuelConsumed += fuel;

        if (remainingFuel <= 0)
        {
            //TODO: erminar partida
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
}
