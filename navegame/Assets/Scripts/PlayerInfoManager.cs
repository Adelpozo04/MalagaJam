using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerInfoManager : MonoBehaviour
{

    public LeaderBoard leaderboard_;

    public TMP_InputField player_input_;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SetupRutine());
        
    }

    public void SetPlayerName()
    {

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
    }

    IEnumerator SetupRutine()
    {
        yield return LoginRutine();
        yield return leaderboard_.FetchTopHighscoreRoutine();
    }

    IEnumerator LoginRutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response =>
        {
            if (response.success)
            {
                Debug.Log("Jugador se unio");
                PlayerPrefs.SetString("PlayerId", (response.player_id + 1).ToString());
                done = true;
            }
            else
            {
                Debug.Log("Jugador no se unio");
                done = true;
            }
        }));

        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
