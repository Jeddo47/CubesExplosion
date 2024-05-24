using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Rigidbody newCube)
    {
        float explosionForce = 10;
        float explosionRadius = 5;
        float upwardsModifier = 1;

        newCube.AddExplosionForce(explosionForce, newCube.transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
    }
}
