using UnityEngine;

public partial class Fish : MonoBehaviour
{
    [SerializeField] private FishType _fishType;

    public FishType Type => _fishType;
}
