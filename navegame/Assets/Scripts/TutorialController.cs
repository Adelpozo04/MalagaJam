using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    //Gestiona la aparición de las distintas partes del tutorial
    //1. La nave con la informacion sobre que se te rompen los sistemas
    //2. La barra de gasolina explicando que si te quedas sin, pierdes
    //3. Los controles explicando que van a cambiar según te quedas sin gasolina

    [SerializeField] private TMP_Text botonText;
    [SerializeField] private GameObject fuelBar;
    [SerializeField] private GameObject controls;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text desc;
    
    private int _stage;
    private void Start()
    {
        _stage = 0;
        Continue();
    }

    public void Continue()
    {
        switch (_stage)
        {
            case 0:
                title.text = "Cuida de tu nave";
                desc.text = "La cosa se pondrá fea si tus sistemas quedan dañados, procura evitar los proyectiles enemigos.";
                break;
            case 1:
                title.text = "¡No te quedes sin gasolina!";
                desc.text = "Perderás gasolina adicional si tus sistemas dañados vuelven a ser golpeados. Puedes conseguir gasolina matando enemigos.";
                fuelBar.SetActive(true);
                break;
            case 2:
                title.text = "¡Los sistemas de control están fallando!";
                desc.text = "A medida que se consuma tu gasolina los controles cambiarán. Se te avisará con antelación. ¡Buena suerte!";
                controls.SetActive(true);
                botonText.text = "VOLVER";
                break;
            case 3:
                SceneManager.LoadScene(0);
                break;
        }
        _stage++;
    }
}
