using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int whosTurn; //0 for x, 1 for 0
    public int turnCount;
    public GameObject[] winnerDisplay;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] ticTacToeSpaces; //playable spaces 
    public int[] markedSpaces; //identifies which tile(space) was marked by wich player
    public GameObject winnerPanel;
    public TextMeshProUGUI xScoreText;
    public TextMeshProUGUI oScoreText;
    public GameObject tieText;
    public GameObject tieImage;
    public GameObject rematchButton;
    public GameObject swithTurnButton;
    private int xPlayersScore;
    private int oPlayersScore;

    private void Start()
    {
        whosTurn = 0;
        GameSetup();
    }

    private void GameSetup()
    {

        swithTurnButton.SetActive(false);
        turnCount = 0;
        turnIcons[0].SetActive(true);


        for (int i = 0; i < ticTacToeSpaces.Length; i++)
        {
            ticTacToeSpaces[i].interactable = true;
            ticTacToeSpaces[i].GetComponent<Image>().sprite = null;
        }

        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }

    public void ticTacToeButton(int whichButton)
    {
        ticTacToeSpaces[whichButton].image.sprite = playerIcons[whosTurn];
        ticTacToeSpaces[whichButton].interactable = false;

        markedSpaces[whichButton] = whosTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            bool isThereWinner = CheckTheWinner();

            if (turnCount == 9 && isThereWinner == false)
            {
                HandleTie();
            }
        }

        if (whosTurn == 0)
        {
            whosTurn = 1;
            turnIcons[1].SetActive(true);
            turnIcons[0].SetActive(false);
        }
        else
        {
            whosTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    private bool CheckTheWinner()
    {
        int solution1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int solution2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int solution3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int solution4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int solution5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int solution6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int solution7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int solution8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];

        int[] solutions = new int[] { solution1, solution2, solution3, solution4, solution5, solution6, solution7, solution8 };

        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3 * (whosTurn + 1))
            {
                DisplayWinner();
                return true;
            }
        }
        return false;
    }

    private void DisplayWinner()
    {
        winnerDisplay[whosTurn].SetActive(true);
        winnerPanel.SetActive(true);
        swithTurnButton.SetActive(true);

        if (whosTurn == 0)
        {
            xPlayersScore++;
            xScoreText.text = xPlayersScore.ToString();
        }
        else if (whosTurn == 1)
        {
            oPlayersScore++;
            oScoreText.text = oPlayersScore.ToString();
        }
        rematchButton.SetActive(true);
    }


    public void RematchButton()
    {
        GameSetup();

        rematchButton.SetActive(false);
        winnerPanel.SetActive(false);
        tieImage.SetActive(false);
        tieText.SetActive(false);

        for (int i = 0; i < winnerDisplay.Length; i++)
        {
            winnerDisplay[i].SetActive(false);
        }
    }

    public void SwitchPlayerButton()
    {
        if (whosTurn == 0)
        {
            whosTurn = 1;
            turnIcons[1].SetActive(true);
            turnIcons[0].SetActive(false);
        }
        else if (whosTurn == 1)
        {
            whosTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    private void HandleTie()
    {
        winnerPanel.SetActive(true);
        tieImage.SetActive(true);
        tieText.SetActive(true);
        rematchButton.SetActive(true);
    }
}