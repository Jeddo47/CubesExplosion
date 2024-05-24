using UnityEngine;

public class CubeMultiplier : MonoBehaviour
{
    [SerializeField] private CameraRaycast _cameraRaycast;
    [SerializeField] private UserUtils _userUtils;
    [SerializeField] private Rigidbody _cube;
    [SerializeField] private float _multiplySuccessChance = 100;
    [SerializeField] private float _minClones = 2;
    [SerializeField] private float _maxClones = 7;
    [SerializeField] private float _scaleDenominator = 2;
    [SerializeField] private float _minPercent = 0;
    [SerializeField] private float _maxPercent = 100;
    [SerializeField] private float _multiplyChanceDenominator = 2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _cameraRaycast.FireRaycast(out RaycastHit hitInfo);

            if (hitInfo.collider != null) 
            {
                if (hitInfo.collider.gameObject == gameObject)
                {
                    MultiplyCube();
                }
            }            
        }
    }

    private void MultiplyCube()
    {        
        if (_userUtils.GetRandomNumber(_minPercent, _maxPercent) <= _multiplySuccessChance)
        {
            transform.localScale /= _scaleDenominator;
            _multiplySuccessChance /= _multiplyChanceDenominator;

            float numberOfClones = _userUtils.GetRandomNumber(_minClones, _maxClones);

            for (int i = 0; i < numberOfClones; i++)
            {                
                Rigidbody newCube = Instantiate(_cube);
                PaintCube(newCube);
                Explode(newCube);
            }
        }

        Destroy(gameObject);
    }

    private void PaintCube(Rigidbody newCube)
    {
        newCube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    private void Explode(Rigidbody newCube)
    {
        float explosionForce = 10;
        float explosionRadius = 5;
        float upwardsModifier = 1;

        newCube.AddExplosionForce(explosionForce, newCube.transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
    }
}
