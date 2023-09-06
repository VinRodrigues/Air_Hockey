using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public int PlayerScore1 = 0;
    public int PlayerScore2 = 0;

    public GUISkin layout;
    private GameObject theDisco;
    private AudioSource audioSource2;
    private List<obstaculo> objetosDestrutiveis = new List<obstaculo>();

    private void Start()
    {
        theDisco = GameObject.FindGameObjectWithTag("Disco");
        audioSource2 = GetComponent<AudioSource>();

        // Encontre e adicione todos os objetos obstaculo à lista.
        objetosDestrutiveis.AddRange(FindObjectsOfType<obstaculo>());
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;

            RestartDisco();
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "CPU WINS");
            RestartDisco();
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            RestartDisco();
        }
    }

    public void Score(string wallID)
    {
        if (wallID == "MiddleRight")
        {
            PlayerScore1++;
            audioSource2.Play();
        }
        else
        {
            PlayerScore2++;
            audioSource2.Play();
        }
    }

    private void RestartDisco()
    {
        if (theDisco != null)
        {
            theDisco.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        // Reinicie todos os objetos obstaculo.
        foreach (var obj in objetosDestrutiveis)
        {
            obj.ResetObject();
        }
    }
}
