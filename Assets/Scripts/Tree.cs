using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    GameObject punta1;
    GameObject punta2;
    GameObject tallo;
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent= GameObject.Find("PlanetSphere");

        createTree(-0.0247950703f,0.363379508f,0.349658608f, 0.0257314425f,0.0840705633f,0.0257314425f, 45.1646233f,12.5647602f,21.9671497f);
        createTree(-0.0570289716f,0.195175707f,0.483170867f, 0.0345460251f,0.112869844f,0.0345460251f,356.16629f,86.6876984f,35.8051643f);
    createTree(0.014322971f,0.248586178f,0.434235424f, 0.0256725736f,0.0838782266f,0.0256725736f, 31.5312786f,5.0971365f,351.515228f);
        createTree(0.0170000009f,0.0659999996f,0.492000014f, 0.0256725736f,0.0838782266f,0.0256725736f, 46.583046f,4.89043665f,4.52956867f);
    createTree(-0.203569919f,0.119904898f,0.463221699f, 0.0256725736f,0.0838782266f,0.0256725736f, 60.8610497f,18.8470821f,16.3125057f);
     

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Auxiliary Methods
    void createTree(float x, float y, float z, float scax, float scay, float scaz, float rotx, float roty, float rotz){
        //Parent-vela1
        tallo= GameObject.CreatePrimitive(PrimitiveType.Cube);
        tallo.transform.parent = parent.transform;
        configureObjectGlobal(tallo, x, y,  z, scax,  scay, scaz, rotx, roty, rotz, new Color(164f,73f,40f,0f) );

        //Children
        punta1= createPyramid("Punta 1");
        configureObjectLocal(punta1, tallo,0f, 0.21f, 1.42f, 3.52f, 1.228723f, 3.37612f, 0f, 0f, 0f,new Color(129,178,20) );

        punta2= createPyramid("Punta 2");
        configureObjectLocal(punta2, tallo,0f, 0.66f, 1.42f, 3.52f, 1.228723f, 3.37612f, 0f, 0f, 0f,new Color(129,178,20) );


    }
    void configureObjectGlobal(GameObject obj, float posx,float posy, float posz,float scalex,float  scaley,float  scalez,float  rotx,float  roty,float rotz,Color color){
        
        obj.transform.localPosition= new Vector3(posx, posy, posz);
        obj.gameObject.transform.localEulerAngles = new Vector3(rotx, roty, rotz);
        obj.gameObject.transform.localScale= new Vector3(scalex, scaley, scalez);
        obj.GetComponent<Renderer>().material.SetColor("_Color", new Color(82f/255f, 57f/255f, 6f/255f));

    }
    void configureObjectLocal(GameObject obj, GameObject parent, float posx,float posy, float posz,float scalex,float  scaley,float  scalez,float  rotx,float  roty,float rotz,Color color){
        
        obj.transform.parent = parent.transform;
        obj.transform.localPosition= new Vector3(posx, posy, posz);
        obj.gameObject.transform.localEulerAngles = new Vector3(rotx, roty, rotz);
        obj.gameObject.transform.localScale= new Vector3(scalex, scaley, scalez);
        obj.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

    }
    
    GameObject createPyramid(string name){

        GameObject obj= new GameObject(name);
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        Vector3[] vertices= new Vector3[4];
        // Pyramid base vertices
        vertices[0] = new Vector3(-1.0f, 0.0f, 0.0f);
        vertices[1] = new Vector3(0.0f, 0.0f, -1.5f);
        vertices[2] = new Vector3(1.0f, 0.0f, 0.0f);
        // Pyramid tip vertex
        vertices[3] = new Vector3(0.0f, 1.0f, -0.8f);

        mesh.vertices= vertices;

        int numTriangles = 4;
        int[] triangleIndices = new int[3 * numTriangles];

        // Botton triangle
        triangleIndices[0] = 0;
        triangleIndices[1] = 1;
        triangleIndices[2] = 2;

        // Side triangles
        triangleIndices[3] = 0;
        triangleIndices[4] = 3;
        triangleIndices[5] = 1;

        triangleIndices[6] = 1;
        triangleIndices[7] = 3;
        triangleIndices[8] = 2;

        triangleIndices[9] = 2;
        triangleIndices[10] = 3;
        triangleIndices[11] = 0;
        mesh.triangles= triangleIndices;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        meshFilter.mesh = mesh;

        return obj;

    }
}
