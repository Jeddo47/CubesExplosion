using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeMultiplier : MonoBehaviour
{
    [SerializeField] private CameraRaycast _cameraRaycast;
    [SerializeField] private UserUtils _userUtils;
    [SerializeField] private Material _cubesMaterial;
    [SerializeField] private float _multiplySuccessChance = 100;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            if (_cameraRaycast.GetColliderInfo().collider.gameObject == gameObject)
            {
                MultiplyCube();
            }
        }
    }

    private void MultiplyCube()
    {
        float minClones = 2;
        float maxClones = 7;
        float scaleDenominator = 2;
        float minPercent = 0;
        float maxPercent = 100;
        float multiplyChanceDenominator = 2;

        if (_userUtils.GetRandomNumber(minPercent, maxPercent) <= _multiplySuccessChance)
        {
            transform.localScale /= scaleDenominator;
            _multiplySuccessChance /= multiplyChanceDenominator;

            float numberOfClones = _userUtils.GetRandomNumber(minClones, maxClones);

            for (int i = 0; i < numberOfClones; i++)
            {
                PaintCube();
                GameObject newCube = Instantiate(gameObject);
                Explode(newCube);
            }
        }

        Destroy(gameObject);
    }

    private void PaintCube()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        _cubesMaterial.color = randomColor;
    }

    private void Explode(GameObject newCube) 
    {
        float explosionForce = 10;
        float explosionRadius = 5;
        float upwardsModifier = 1;

        newCube.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, newCube.transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
    }
}
