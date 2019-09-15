using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardInit : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameBoard;
    [SerializeField]
    private GameObject _boardPrefab;


    // Start is called before the first frame update
    void Start()
    {
        int gridNum = _gameBoard.GetComponent<GameBoard>().GridNum;
        GameObject[,] boardObjectArray = new GameObject[gridNum, gridNum];

        _gameBoard.GetComponent<GameBoard>().InitColor = _boardPrefab.GetComponent<Image>().color;

        for (int i = 0; i < gridNum; i++)
        {
            for (int j = 0; j < (gridNum); j++)
            {
                GameObject board = Instantiate(_boardPrefab, _gameBoard.transform);
                boardObjectArray[j, gridNum - 1 - i] = board;
            }
        }
        _gameBoard.GetComponent<GameBoard>().BoardObjectArray = boardObjectArray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
