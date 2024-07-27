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

    public IEnumerator FetchTopHighscoreRoutine()
    {
        bool done = false;

        LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }

                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }

                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.errorData);
                done = true;
            }
        });

        yield return new WaitWhile (()=> done == false);
    }
}
