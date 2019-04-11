using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced from https://docs.unity3d.com/ScriptReference/Camera.RenderToCubemap.html

[ExecuteInEditMode]
public class CubeMap : MonoBehaviour {

    int cubemapSize = 128;
    bool oneFacePerFrame = false;
    Camera cam;
    RenderTexture renderTexture;

	// Use this for initialization
	void Start ()
    {
        // render all six faces at startup
        UpdateCubemap(63);
	}

    void OnDisable()
    {
        DestroyImmediate(cam);
        DestroyImmediate(renderTexture);
    }

    void LateUpdate()
    {
        if (oneFacePerFrame)
        {
            var faceToRender = Time.frameCount % 6;
            var faceMask = 1 << faceToRender;
            UpdateCubemap(faceMask);
        }
        else
        {
            UpdateCubemap(63); // all six faces
        }
    }

    // Update is called once per frame
    void UpdateCubemap (int faceMask)
    {
	    if (!cam)
        {
            GameObject obj = new GameObject("CubemapCamera", typeof(Camera));
            obj.hideFlags = HideFlags.HideAndDontSave;
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            cam = obj.GetComponent<Camera>();
            cam.farClipPlane = 100; // don't render far into the cubemap
            cam.enabled = false;
        }

        if (!renderTexture)
        {
            renderTexture = new RenderTexture(cubemapSize, cubemapSize, 16);
            renderTexture.dimension = UnityEngine.Rendering.TextureDimension.Cube;
            renderTexture.hideFlags = HideFlags.HideAndDontSave;
            GetComponent<SkinnedMeshRenderer>().sharedMaterial.SetTexture("_Cube", renderTexture);
        }

        cam.transform.position = transform.position;
        cam.RenderToCubemap(renderTexture, faceMask);
	}
}
