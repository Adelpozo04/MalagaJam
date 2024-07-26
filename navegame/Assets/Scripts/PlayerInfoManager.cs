using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class PlayerInfoManager : MonoBehaviour
{

    public LeaderBoard leaderboard_;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SetupRutine());
        
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
                PlayerPrefs.SetString("Player Id", response.player_id.ToString());
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
