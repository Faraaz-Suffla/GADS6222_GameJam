using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _CompleteClip;

    private PuzzlePiece occupiedPiece; // Variable to store the puzzle piece placed in the slot

    public void Placed()
    {
        _source.PlayOneShot(_CompleteClip);
    }

    public bool IsOccupied()
    {
        return occupiedPiece != null; // Check if the slot is occupied by a puzzle piece
    }

    public void PlacePiece(PuzzlePiece piece)
    {
        occupiedPiece = piece; // Assign the piece that is placed in the slot
    }

    public void RemovePiece()
    {
        occupiedPiece = null; // Remove the piece from the slot
    }
}
