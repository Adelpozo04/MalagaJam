using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerInfoManager : MonoBehaviour
{

    public LeaderBoard leaderboard_;

    [SerializeField] private GameObject buttons_;

    public TMP_InputField player_input_;

    string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetPlayerName()
    {

        name = player_input_.text;

        StartCoroutine(SetupRutine());

        buttons_.SetActive(true);

    }

    IEnumerator SetupRutine()
    {
        yield return LoginRutine();
        yield return leaderboard_.FetchTopHighscoreRoutine();
    }

    IEnumerator LoginRutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession(name + " ", (response =>
        {

            if (response.success)
            {
                Debug.Log("Jugador se unio");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Jugador no se unio");
                done = true;
            }

            LootLockerSDKManager.SetPlayerName(player_input_.text, (response) =>
            {
                if (response.success)
                {
                    Debug.Log("Nombre puesto correcto");
                }
                else
                {
                    Debug.Log("Fallo en eleccion de nombre" + response.errorData);
                }
            });
        }));

        yield return new WaitWhile(() => done == false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
