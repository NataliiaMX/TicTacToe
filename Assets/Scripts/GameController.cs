using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int whosTurn; //0 for x, 1 for 0
    public int turnCount;
    public GameObject[] _turnIcons;
    public Sprite[] _playerIcons; 
    public Button[] _ticTacToeSpaces; //playable spaces 

    private void Start() 
    {
        GameSetup();
    }

    private void GameSetup()
    {
        whosTurn = 0;
        turnCount = 0;
        _turnIcons[0].SetActive(true);
        _turnIcons[1].SetActive(false);

        for(int i = 0; i < _ticTacToeSpaces.Length; i++)
        {
            _ticTacToeSpaces[i].interactable = true;
            _ticTacToeSpaces[i].GetComponent<Image>().sprite = null;
        }
    }
}
