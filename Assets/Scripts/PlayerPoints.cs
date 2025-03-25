using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdatePoints(int victories, int maxRounds)
    {
        string points = "";

        for (int i = 0; i < victories; i++)
        {
            points += "o ";
        }
        for (int i = 0; i < maxRounds - victories; i++)
        {
            points += "- ";
        }

        text.text = text.text.Substring(0, text.text.IndexOf("\n") + 1) + points;
    }

    public void ResetPoints(int maxRounds)
    {
        string points = "";
        for (int i = 0; i < maxRounds; i++)
        {
            points += "- ";
        }

        text.text = text.text.Substring(0, text.text.IndexOf("\n") + 1) + points;
    }
}
