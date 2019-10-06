using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardInit : MonoBehaviour
{
    [SerializeField]
    private GameBoard _gameBoard;
    [SerializeField]
    private Image _boardPrefab;

    // Start is called before the first frame update
    public void GameBoardInitialize(int gridNum)
    {
        Image[,] boardImageArray = new Image[gridNum, gridNum];

        _gameBoard.InitColor = _boardPrefab.color;

        for (int i = 0; i < gridNum; i++)
        {
            for (int j = 0; j < (gridNum); j++)
            {
                Image board = Instantiate(_boardPrefab, _gameBoard.transform);
                boardImageArray[j, gridNum - 1 - i] = board;
            }
        }
        _gameBoard.SetBoardImageArray(boardImageArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
