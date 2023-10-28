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
        Spawn();
    }

    void Spawn()
    {
        if (_slotPrefabs.Count != 0 && _piecePrefabs.Count != 0 && _slotPrefabs.Count == _piecePrefabs.Count)
        {
            for (int i = 0; i < _slotPrefabs.Count; i++)
            {
                var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity);
                var spawnedPiece = Instantiate(_piecePrefabs[i], _pieceParent.GetChild(i).position, Quaternion.identity);
                spawnedPiece.Init(spawnedSlot);
            }
        }
        else
        {
            Debug.LogWarning("Slot prefabs or piece prefabs lists are either empty or have different sizes.");
        }
    }
}
