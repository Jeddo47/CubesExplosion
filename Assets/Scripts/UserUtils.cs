using UnityEngine;

public class UserUtils : MonoBehaviour
{
    public float GetRandomNumber(float min, float max)
    {
        float randomNumber = Random.Range(min, max);

        return randomNumber;
    }
}
