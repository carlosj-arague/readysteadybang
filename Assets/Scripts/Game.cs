using UnityEngine;
using System.Collections;
using TMPro;

public class Game : MonoBehaviour
{

    public CharacterAction Player1;
    public CharacterAction Player2;

    public PlayerPoints UIPointsPlayer1;
    public PlayerPoints UIPointsPlayer2;
    public TMP_Text screenText;

    public int PointsPlayer1 = 0;
    public int PointsPlayer2 = 0;

    public int maxRounds = 5;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.P));

        screenText.text = "Game Start!";

        yield return new WaitForSeconds(1f);
        
        StartCoroutine(WaitForBang());
    }
    IEnumerator WaitForBang()
    {
        while (PointsPlayer1 < maxRounds && PointsPlayer2 < maxRounds)
        {

            Player1.CharacterResetPosition();
            Player2.CharacterResetPosition();

            screenText.text = "Ready...";
            yield return new WaitForSeconds(1.2f);
            screenText.text = "Steady...";
            float s = (Random.Range(500, 0) + 150.0f) / 100.0f;
            yield return new WaitForSeconds(s);
            screenText.text = "BANG!";


            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.P));


            if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.P))
            {
                Player1.CharacterShoot();
                Player2.CharacterShoot();
                PointsPlayer1 += 1;
                PointsPlayer2 += 1;
                UIPointsPlayer1.UpdatePoints(PointsPlayer1, maxRounds);
                UIPointsPlayer2.UpdatePoints(PointsPlayer2, maxRounds);

                screenText.text = "It's a tie!\nPress Space to continue";
                yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Player1.CharacterShoot();
                    PointsPlayer1 += 1;
                    UIPointsPlayer1.UpdatePoints(PointsPlayer1, maxRounds);

                    screenText.text = "Player 1 Wins!\nPress Space to continue";
                    yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Player2.CharacterShoot();
                    PointsPlayer2 += 1;
                    UIPointsPlayer2.UpdatePoints(PointsPlayer2, maxRounds);

                    screenText.text = "Player 2 Wins!\nPress Space to continue";
                    yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
                }
            }
        }


        if (PointsPlayer1 > PointsPlayer2)
        {
            screenText.text = "Player 1 Won! Congratulations!\nPlay again? (Y/N)";
        } else
        {
            screenText.text = "Player 2 Won! Congratulations!\nPlay again? (Y/N)";
        }

        yield return new WaitUntil(() => Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.N));


        if (Input.GetKey(KeyCode.Y))
        {
            PointsPlayer1 = 0;
            PointsPlayer2 = 0;
            UIPointsPlayer1.ResetPoints(maxRounds);
            UIPointsPlayer2.ResetPoints(maxRounds);
            StartCoroutine(WaitForBang());
        } else
        {
            screenText.text = "Thanks for playing!";
        }
            
    }

}
