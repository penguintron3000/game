using UnityEngine;

public class ClipController : MonoBehaviour
{
    public Transform parentTransform;
    public Material clippingMaterial;

    void Awake()
    {
        if (parentTransform != null && clippingMaterial != null)
        {
            // Calculate the parent's bounds in world space
            Renderer parentRenderer = parentTransform.GetComponent<Renderer>();
            if (parentRenderer != null)
            {
                Bounds parentBounds = parentRenderer.bounds;

                Vector4 clipRect = new Vector4(parentBounds.min.x, parentBounds.min.y, parentBounds.max.x, parentBounds.max.y);
                //Vector4 clipRect = new Vector4(-1, -0, 10, 3);

                // Pass the bounds to the shader
                clippingMaterial.SetVector("_ClipRect", clipRect);
            }
        }
    }
}