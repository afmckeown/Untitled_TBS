using System.Runtime.CompilerServices;
using UnityEngine;

public class EditModeGridSnap : MonoBehaviour
{
    private Transform Transform { get; set; }

    private void Awake()
    {
        Transform = gameObject.transform;
    }

    private void Update()
    {
        if (!Application.isEditor || Application.isPlaying) return;

        Transform.position = Board.AdjustWorldPoint(Transform.position);
    }
}