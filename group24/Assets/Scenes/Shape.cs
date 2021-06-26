using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour {

    
    public Slider s_Res;
    public Slider s_Rad;
    int resolution = 2;
    public ShapeSettings shapeSettings;
    public ShapeGenerator shapeGenerator;
    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;

    void Start()
    {
        s_Res.maxValue = 50;
        s_Res.minValue = 2;

        s_Rad.maxValue = 10;
        s_Rad.minValue = .5f;
    }

     void Update()
    {
        resolution = (int) s_Res.value;
        shapeSettings.shapeRadius = s_Rad.value;
        Initialize();
        GenerateMesh();
    }
     
	private void OnValidate()
	{
        GeneratePlanet();
	}

	void Initialize()
    {   
        shapeGenerator = new ShapeGenerator(shapeSettings);

        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new TerrainFace[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }
    public void  GeneratePlanet() {
        Initialize();
        GenerateMesh();
    }
    public void OnShapeSettingsUpdated() {
        Initialize();
        GenerateMesh();
    }

    void GenerateMesh()
    {
        foreach (TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

}