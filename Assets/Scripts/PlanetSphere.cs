using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSphere : MonoBehaviour
{
    GameObject planet;
    GameObject camera;
    GameObject terrain;
    // Start is called before the first frame update
    void Start()
    {
        //Parent-vela1
        //Se llama el objeto global para asociar a los hijos.
        planet= GameObject.Find("PlanetSphere");


        //Se crean los objetos.
        configureObjectGlobal(planet,32.64943f, -0.7301698f, -6.200824f, 50.96099f, 50.96099f, 50.96099f, 247.725f, 31.808f, 13.845f, new Color(0f/255f,  158f/255f, 148f/255f) );
        camera= GameObject.Find("Main Camera");
        camera.transform.position= new Vector3(61f,26.7999992f,48.5999985f);
        camera.gameObject.transform.localEulerAngles = new Vector3(22.245f, -142.898f,0f);

        terrain= GameObject.CreatePrimitive(PrimitiveType.Sphere);
        configureObjectLocal(terrain,planet,0f, 0.02f,0f, 1f, 1.001f, 1f, 0f, 0f, 0f, Color.green );
        
        


    }

    // Update is called once per frame
    void Update()
    {
        planet.gameObject.transform.Rotate(0.15f, 0,0);
    }

    //Auxiliary Methods

    void configureObjectGlobal(GameObject obj, float posx,float posy, float posz,float scalex,float  scaley,float  scalez,float  rotx,float  roty,float rotz,Color color){
        
        obj.transform.position= new Vector3(posx, posy, posz);
        obj.gameObject.transform.localEulerAngles = new Vector3(rotx, roty, rotz);
        obj.gameObject.transform.localScale= new Vector3(scalex, scaley, scalez);
        obj.GetComponent<Renderer>().material.SetColor("_Color", color);

    }
     void configureObjectLocal(GameObject obj, GameObject parent, float posx,float posy, float posz,float scalex,float  scaley,float  scalez,float  rotx,float  roty,float rotz,Color color){
        
        obj.transform.parent = parent.transform;
        obj.transform.localPosition= new Vector3(posx, posy, posz);
        obj.gameObject.transform.localEulerAngles = new Vector3(rotx, roty, rotz);
        obj.gameObject.transform.localScale= new Vector3(scalex, scaley, scalez);
        obj.GetComponent<Renderer>().material.SetColor("_Color", color);

    }
}
