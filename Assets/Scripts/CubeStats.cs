using UnityEngine;

public class CubeStats : MonoBehaviour
{    
    [SerializeField] private float _multiplySuccessChance = 100;
    [SerializeField] private float _minPercent = 0;
    [SerializeField] private float _maxPercent = 100;
    [SerializeField] private float _multiplyChanceDenominator = 2;

    public bool IsAbleToMultiply()
    {
        return Random.Range(_minPercent, _maxPercent) <= _multiplySuccessChance;
    }

    public void DecreaseMultiplyChance()
    {
        _multiplySuccessChance /= _multiplyChanceDenominator;
    }
}
