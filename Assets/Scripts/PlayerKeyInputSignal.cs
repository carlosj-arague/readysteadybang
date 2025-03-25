using System.Collections;
using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public TMP_Text Player1Key;
    public TMP_Text Player2Key;


    private void Awake()
    {
        StartCoroutine(SignalPlayer1());
        StartCoroutine(SignalPlayer2());
    }

    IEnumerator SignalPlayer1()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
            Player1Key.color = Color.green;
            yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Q));
            Player1Key.color = Color.white;
        }

    }

    IEnumerator SignalPlayer2()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.P));
            Player2Key.color = Color.green;
            yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.P));
            Player2Key.color = Color.white;
        }
    }
}
