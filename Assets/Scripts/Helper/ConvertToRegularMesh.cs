using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour {

    // Add this selection in the editor (gear icon)
    [ContextMenu("Convert to regular mesh")]
	void Convert ()
    {
        // Get SkinnedMeshRenderer component of the game object
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        
        // Add a Mesh Renderer to the game object
        MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>();

        // Add a Mesh Filter to the game object
        MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();


        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

        // Destroy the Mesh Renderer component and this script on the object
        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
