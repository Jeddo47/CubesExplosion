using UnityEngine;

[RequireComponent (typeof(Renderer))]

public class CubeStats : MonoBehaviour
{    
    [SerializeField] private float _multiplySuccessChance = 100;
    [SerializeField] private float _minPercent = 0;
    [SerializeField] private float _maxPercent = 100;
    [SerializeField] private float _multiplyChanceDenominator = 2;
    [SerializeField] private float _explosionPotential = 1;
    [SerializeField] private float _explosionPotentialMultiplier = 2;

    public float ExplosionPotential { get; private set; }

    public bool IsAbleToMultiply()
    {
        return Random.Range(_minPercent, _maxPercent) <= _multiplySuccessChance;
    }

    public void DecreaseMultiplyChance()
    {
        _multiplySuccessChance /= _multiplyChanceDenominator;
    }

    public void IncreaseExplosionPotential() 
    {
        _explosionPotential *= _explosionPotentialMultiplier;
        ExplosionPotential = _explosionPotential;
    }

    private void Awake()
    {
        ExplosionPotential = _explosionPotential;
    }
}
