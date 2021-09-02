using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GLTFLoader : MonoBehaviour
{
    public GameObject gltfPrefab;
    public string gltfURL = "https://hivemind.blob.core.windows.net/central-platform/users/user-578/assets/3d/1629278331_Pinocchio_Anim.glb";

    [Space]
    public TextMeshProUGUI debugText;

    // Start is called before the first frame update
    //void Start()
    //{
    //    GameObject newGLTFObject = Instantiate(gltfPrefab);
    //    var gltf = newGLTFObject.AddComponent<GLTFast.GltfAsset>();
    //    gltf.url = gltfURL;
    //}

    async void Start()
	{


        float startTime = Time.time;

        var gltf = new GLTFast.GltfImport();

        Debug.Log("Start Loading...");
        var success = await gltf.Load(gltfURL);

        float interval = Time.time - startTime;

        if (success)
		{
            // Instantiate the glTF's main scene
            gltf.InstantiateMainScene(new GameObject("Instance 1").transform);

            //// Instantiate each of the glTF's scenes
            //for (int sceneId = 0; sceneId < gltf.sceneCount; sceneId++)
            //{
            //    gltf.InstantiateScene(transform, sceneId);
            //}
                debugText.text = debugText.text + "Loading Success: " + interval.ToString() + "s";

        }
        else
		{
            debugText.text = debugText.text + "Loading Failed: " + interval.ToString() + "s";
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
