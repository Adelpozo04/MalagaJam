using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoard : MonoBehaviour
{

    string leaderboardID = "23642";

    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //AÑADIR LLAMADA EN EL METODO EN EL QUE MUERE EL JUGADOR
    public IEnumerator SumbitScoreRoutine(int scoreToUpload)
    {
        bool done = false;

        string playerID = PlayerPrefs.GetString("PlayerID");

        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Enviada puntuacion bien");
                done = true;
            }
            else
            {
                Debug.Log("Fallo" + response.errorData);
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);
    }
}
