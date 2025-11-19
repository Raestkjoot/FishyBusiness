using UnityEngine;

public class FishTank : MonoBehaviour
{
    [SerializeField] private FishType _fishType;

    private void OnMouseEnter()
    {
        Debug.Log("Mouse is over " + GetFishName(_fishType) + " fish.");
    }

    private string GetFishName(FishType type)
    {
        switch (type)
        {
            case FishType.A:
                return "A";
            case FishType.B:
                return "B";
            case FishType.C:
                return "C";
        }

        return "Error";
    }
}
