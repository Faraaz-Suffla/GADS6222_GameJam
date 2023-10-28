using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private List<PuzzlePiece> _piecePrefabs;
    [SerializeField] private Transform _slotParent, _pieceParent;

    private void Start()
    {
        SpawnSlots();
        SpawnPieces();
    }

    void SpawnSlots()
    {
        if (_slotPrefabs.Count != 0)
        {
            for (int i = 0; i < _slotPrefabs.Count; i++)
            {
                Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity, _slotParent);
            }
        }
        else
        {
            Debug.LogWarning("Slot prefabs list is empty.");
        }
    }

    void SpawnPieces()
    {
        if (_piecePrefabs.Count != 0)
        {
            for (int i = 0; i < _piecePrefabs.Count; i++)
            {
                Instantiate(_piecePrefabs[i], _pieceParent.GetChild(i).position, Quaternion.identity, _pieceParent);
            }
        }
        else
        {
            Debug.LogWarning("Piece prefabs list is empty.");
        }
    }
}
