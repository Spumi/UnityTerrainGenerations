using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class meshGenerator : MonoBehaviour {

    Vector3[] verticies;
    public int[] triangles;
    public int xSize = 10;
    public int zSize = 10;
    public int xOffset = 10;
    public int zOffset = 10;
    public float scale = 4;
    public float scale2 = 8;
    public int zScale = 10;
    public int xScale = 10;
    GameObject terrain;
    Mesh mesh;
    MeshCollider collider;
    // Use this for initialization
    void Start() {
        mesh = new Mesh();
        //GetComponent<MeshFilter>().mesh = mesh;
        mesh = GetComponent<MeshFilter>().mesh;
        collider = gameObject.AddComponent<MeshCollider>() as MeshCollider;
        collider.sharedMesh = mesh;

        createShape();
        updateMesh();
        
    }

    // Update is called once per frame
   
    void Update() {
        createShape();
        updateMesh();

    }
    
    void createShape()
    {
                verticies = new Vector3[((xSize +1) * (zSize +1))];
        for (int i = 0, z = 0; z <= zSize; z++){
            for (int x = 0; x <= zSize; x++){
                float y = Mathf.PerlinNoise((float)x * (xScale * .001f) + (xOffset * .001f), (float)z *(zScale  * .001f) + (zOffset * .001f)) * scale;
               // y += ((Mathf.PerlinNoise(Mathf.Pow((float)x,2), Mathf.Pow((float)z,2)) * 2) - 1)*2;
                //y += (Mathf.PerlinNoise(Mathf.Pow((float)x, 3) * .2f, Mathf.Pow((float)z, 3) * 2f ) * 2 - 1)/3;
                verticies[i] = new Vector3(x, y, z);
                i++;
            }
        }

        //for (int i = 0; i < verticies.Length; i++)
        //{
        //    if (i % 10 == 0)
        //    verticies[i].y += Mathf.PerlinNoise(verticies[i].x * (xScale * .001f) + (xOffset * .001f), verticies[i].z * (zScale * .001f) + (zOffset * .001f)) * scale2;
        //}

        int vert = 0;
        int tris = 0;
        triangles = new int[xSize * zSize *6];

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        
      
    }

    void updateMesh(){
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;



        mesh.RecalculateNormals();
        mesh.RecalculateBounds();


        MeshFilter mf = gameObject.GetComponent<MeshFilter>();

       // collider.convex = true;
        collider.sharedMesh = mesh;
        collider.enabled = true;



        //var collider = GetComponent<TerrainCollider>();
        //collider.terrainData = null;
        //collider.terrainData = (TerrainDa0ta)mesh;
    }

    private void OnDrawGizmos()
    {
        if (verticies == null)
            return;
        //for (int i = 0; i < verticies.Length; i++){
        //    Gizmos.DrawSphere(verticies[i], .1f);
           
        //}

    }

}
