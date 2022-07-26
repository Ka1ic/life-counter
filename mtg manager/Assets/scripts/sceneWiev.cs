using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class sceneWiev : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text[] fieldText;
    public GameObject[] field;
    int numPlayers;
    int numLifes = 20;
    int[] valuesOfLifes = new int[4];
    string[] NamesOfScenes = new string[4];
    int lastNumberOfLifes = 0;

    void Start()
    {
        DataHolder.numLifes = 20;
        NamesOfScenes[0] = "one_player";
        NamesOfScenes[1] = "two_players";
        NamesOfScenes[2] = "three_players";
        NamesOfScenes[3] = "four_players";
        valuesOfLifes[0] = 20;
        valuesOfLifes[1] = 25;
        valuesOfLifes[2] = 30;
        valuesOfLifes[3] = 40;
    }

    public void playerValue(int numberPlayers)
    {
        numPlayers = numberPlayers;
    }

    public void lifeValue(int numberLifes)
    {
        if(numberLifes < 4)
        {
            DataHolder.numLifes = valuesOfLifes[numberLifes];
            field[0].SetActive(false);
        }
        else
        {
            field[0].SetActive(true);
            DataHolder.numLifes = lastNumberOfLifes;
        }
    }

    public void tap(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OterNumberOfLifes(string CountOfLifes)
    {
        if(CountOfLifes == "")
        {
            lastNumberOfLifes = 0;
            DataHolder.numLifes = lastNumberOfLifes;
        }
        else
        {
            lastNumberOfLifes = Convert.ToInt32(CountOfLifes);
            DataHolder.numLifes = lastNumberOfLifes;
        }
    }

    public void moveToPlayMode()
    {
        SceneManager.LoadScene(NamesOfScenes[numPlayers]);
    }
}
