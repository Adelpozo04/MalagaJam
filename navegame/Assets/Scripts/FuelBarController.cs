
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    [SerializeField] private int totalFuel;
    [SerializeField] private int remainingFuel;
    [SerializeField] private Vector2 innerBarProportions;
    
    [SerializeField] private GameObject _innerBar;
    private Image _innerImage;
    
    void Start()
    {
        //Inicializa la barra interior al tamaño y la posición adecuada
        _innerImage = _innerBar.GetComponent<Image>();
        RestartFuelBar();
    }

    public void AddFuel(int fuel)
    {
        remainingFuel += fuel;
        if (remainingFuel >= totalFuel)
        {
            remainingFuel = totalFuel;
        }
        UpdateBar();
    }

    public void SubstractFuel(int fuel)
    {
        remainingFuel -= fuel;
        if (remainingFuel <= 0)
        {
            //TODO: erminar partida
        }
        UpdateBar();
    }
    
    public void RestartFuelBar()
    {
        remainingFuel = totalFuel;
        UpdateBar();
    }

    private void UpdateBar()
    {
        _innerImage.fillAmount = (float) remainingFuel / totalFuel;
    }
}
