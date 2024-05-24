using UnityEngine;

public class Painter : MonoBehaviour
{
    public void PaintCube(Rigidbody newCube)
    {
        newCube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}
