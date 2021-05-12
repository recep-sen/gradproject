using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TerrainGenerator : MonoBehaviour
{
    public Material[] materials;


    public int width = 256;                                                         // terrain volumes stored in variables
    public int height = 256;
    public int depth = 20;

    public float offsetx = 100f;                                                    //random values to randomize terrain
    public float offsety = 100f;

    public float scale = 20f;                                                       //scale to zoom in or out

    void Awake()
    {
        //surfaces = GetComponent<NavMeshSurface>();
        offsetx = Random.Range(0f, 99999f);                                         //randomizing
        offsety = Random.Range(0f, 99999f);
        Terrain terrain = GetComponent<Terrain>();                                   //getting component
        terrain.terrainData = GenerateTerrain(terrain.terrainData);                  //changing terraindata to our generated data
                                                                                     //surfaces.BuildNavMesh();
        Material chosenone = materials[Random.Range(0, materials.Length)];
        terrain.materialTemplate = chosenone;
    }



    TerrainData GenerateTerrain(TerrainData terrainData)                                    //this method generates terrain data and returns it
    {                                                                                       //sets size and resolution also calls method that generate heights
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()                                                                  //this method loops through every pixel(perlin noise not color) and calculates a random one
    {                                                                                           //also it calls calculate method which is where it gets random perlin noise color
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)                                                           //this method is the one generates random perlin noise pixel with modifiers taken at the top
    {
        float xCoord = (float)x / width * scale + offsetx;
        float yCoord = (float)y / width * scale + offsety;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}