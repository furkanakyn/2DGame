using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridManager gridManager;

    public Vector2 gridKey;

    public Piece piecePrefab;

    public List<Piece> pieces;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PassTurn();
        }
    }
    public void Init()
    {
        StartCoroutine(GeneratePiecesCoroutine());
    }

    IEnumerator GeneratePiecesCoroutine()
    {
        while (true)
        {
            PassTurn();
            yield return new WaitForSeconds(3);            
        }
    }

    private void PassTurn()
    {
        MovePiecesDown();
        GenerateNewPiece();
    }

    private void MovePiecesDown()
    {
        foreach (var p in pieces)
        {
            // p.transform.position = p.transform.position + Vector3.down;
            p.transform.DOMoveY(p.transform.position.y - 1, 1f);
        }
    }

    private void GenerateNewPiece()
    {
        var xKey = UnityEngine.Random.Range(0, gridManager.xSize);
        var yKey = gridManager.ySize - 1;
        var newPiece = Instantiate(piecePrefab);
        newPiece.transform.position = gridManager.GetGrid(new Vector2(xKey, yKey)).transform.position;
        newPiece.Init();
        pieces.Add(newPiece);
    }   
}
