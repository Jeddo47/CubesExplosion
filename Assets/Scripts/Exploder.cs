using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForceOnSpawn = 15;
    [SerializeField] private float _explosionRadiusOnSpawn = 10;
    [SerializeField] private float _explosionForceOnDestroy = 10;
    [SerializeField] private float _explosionRadiusOnDestroy = 10;
    [SerializeField] private float _upwardsModifier = 1;

    public void ExplodeOnSpawn(Rigidbody newCube)
    {
        newCube.AddExplosionForce(_explosionForceOnSpawn, newCube.transform.position, _explosionRadiusOnSpawn, _upwardsModifier, ForceMode.Impulse);
    }

    public void ExplodeOnDestroy(RaycastHit hitInfo, CubeStats cubeStats)
    {
        float explosionPotential = cubeStats.GetExplosionPotential();

        foreach (var cubeToExplode in GetCubesToExplode(hitInfo))
        {
            float distanceFromExplosion = Vector3.Distance(hitInfo.collider.transform.position, cubeToExplode.transform.position);
            float explosionForceModifier = 1 - distanceFromExplosion / _explosionRadiusOnDestroy;

            cubeToExplode.AddExplosionForce(_explosionForceOnDestroy * explosionForceModifier * explosionPotential, hitInfo.collider.transform.position, 
                                            _explosionRadiusOnDestroy * explosionPotential, _upwardsModifier, ForceMode.Impulse);
        }
    }

    private List<Rigidbody> GetCubesToExplode(RaycastHit hitInfo)
    {
        Collider[] hits = Physics.OverlapSphere(hitInfo.collider.transform.position, _explosionRadiusOnDestroy);

        List<Rigidbody> cubesToExplode = new List<Rigidbody>();

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out CubeStats cubeStats))
            {
                cubesToExplode.Add(hit.attachedRigidbody);
            }
        }

        return cubesToExplode;
    }
}
