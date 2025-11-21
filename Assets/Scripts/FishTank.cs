using UnityEngine;

public class FishTank : MonoBehaviour
{
    [SerializeField] private Fish.FishType _fishType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Fish fish = other.GetComponent<Fish>();
            Debug.Log("Fish_" + Fish.GetFishName(fish.Type) + " added to FishTank_" + Fish.GetFishName(_fishType) + " | " + (_fishType == fish.Type ? "correct" : "incorrect"));
        }
    }
}
