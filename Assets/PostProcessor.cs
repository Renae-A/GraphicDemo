using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessor : MonoBehaviour {

    public Material mat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        mat.SetFloat("_DeltaX", 1.0f / (float)source.width);
        mat.SetFloat("_DeltaY", 1.0f / (float)source.height);

        Graphics.Blit(source, destination, mat);
    }
}
