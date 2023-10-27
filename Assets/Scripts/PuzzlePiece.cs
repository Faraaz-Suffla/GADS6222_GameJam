using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging;

    private void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
    }
}
