using UnityEngine;

public class ClipController : MonoBehaviour
{
    public Material clipMaterial;
    public Vector4 clipPlane;

    void Update()
    {
        if (clipMaterial != null)
        {
            clipMaterial.SetVector("_ClipPlane", clipPlane);
        }
    }
}