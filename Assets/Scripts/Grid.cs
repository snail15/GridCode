using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;


public class Grid {
    private int _width;
    private int _height;
    private float _cellSize;
    private int[,] _gridArray;
    private TextMesh[,] _debugArray;
    private Vector3 _originPos;

    public Grid(int width, int height, float cellSize, Vector3 originPos)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _originPos = originPos;

        _gridArray = new int[width, height];
        _debugArray = new TextMesh[width, height];

        for (int row = 0; row < _gridArray.GetLength(1); row++)
        {
            for (int col = 0; col < _gridArray.GetLength(0); col++)
            {
                _debugArray[col, row] =  UtilsClass.CreateWorldText(_gridArray[col, row].ToString(),null, GetWorldPosition(col, row) + new Vector3(_cellSize, _cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(col, row), GetWorldPosition(col, row + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(col, row), GetWorldPosition(col + 1, row ), Color.white, 100f);
            }
        }
        
        Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width, _height ), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(_width,0), GetWorldPosition(_width, _height ), Color.white, 100f);
        
        SetValue(2,0,56);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize + _originPos;
    }

    private void GetXY(Vector3 worldPos, out int x, out  int y)
    {
        x = Mathf.FloorToInt((worldPos - _originPos).x / _cellSize);
        y = Mathf.FloorToInt((worldPos - _originPos).y / _cellSize);
    }

    public void SetValue(int col, int row, int value)
    {
        if (col >= 0 && row >= 0 && col < _width && row < _height)
        {
            _gridArray[col, row] = value;
            _debugArray[col, row].text = _gridArray[col, row].ToString();
        }
    }

    public void SetValue(Vector3 worldPos, int value)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int col, int row)
    {
        if (col >= 0 && row >= 0 && col < _width && row < _height)
        {
            return _gridArray[col, row];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPos)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        return GetValue(x, y);
    }
    

  
}
