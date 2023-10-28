using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (_slotPrefabs.Count != 0)
        {
            for (int i = 0; i < _slotPrefabs.Count; i++)
            {
                var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity);
                var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
                spawnedPiece.Init(spawnedSlot);
            }
        }
        else
        {
            Debug.LogWarning("No slot prefabs found in the list.");
        }
    }
}
