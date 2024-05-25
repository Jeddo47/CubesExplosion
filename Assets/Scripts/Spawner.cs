using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _minClones = 2;
    [SerializeField] private float _maxClones = 6;
    [SerializeField] private float _scaleDenominator = 2;
    [SerializeField] private Painter _painter;
    [SerializeField] private Exploder _exploder;

    public void MultiplyCubes(RaycastHit hitInfo, CubeStats cubeStats)
    {
        if (cubeStats.IsAbleToMultiply())
        {
            float numberOfClones = Random.Range(_minClones, _maxClones);

            cubeStats.DecreaseMultiplyChance();
            cubeStats.IncreaseExplosionPotential();

            for (int i = 0; i < numberOfClones; i++)
            {
                Rigidbody newCube = Instantiate(hitInfo.collider.attachedRigidbody);
                newCube.transform.localScale /= _scaleDenominator;
                _painter.PaintCube(newCube);
                _exploder.ExplodeOnSpawn(newCube);
            }
        }
        else 
        {
            _exploder.ExplodeOnDestroy(hitInfo, cubeStats);                    
        }

        Destroy(hitInfo.collider.gameObject);
    }
}
