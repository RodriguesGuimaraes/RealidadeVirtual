using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 50.0f;
    public Material cubeMaterial;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
        
        mesh.vertices = new Vector3[]
        {
            //frontal
            new Vector3(-1,-1,1),    // esq,inf,frente 0
            new Vector3(-1,1,1),     // esq,sup,frente 1
            new Vector3(1,-1,1),     // dir,inf,frente 2
            new Vector3(1,1,1),      // dir,sup,frente 3
            //lateral esquerda
            new Vector3(-1,1,-1),    // esq,sup,tras   4
            new Vector3(-1,-1,-1),   // esq,inf,tras   5
            new Vector3(-1,1,1),     // esq,sup,frente 6
            new Vector3(-1,-1,1),    // esq,inf,frente 7
            //lateral direita
            new Vector3(1,1,-1),     // dir,sup,tras   8
            new Vector3(1,-1,-1),    // dir,inf,tras   9
            new Vector3(1,1,1),      // dir,sup,frente 10
            new Vector3(1,-1,1),     // dir,inf,frente 11
            //atras
            new Vector3(-1,-1,-1),   // esq,inf,tras  12
            new Vector3(-1,1,-1),    // esq,sup,tras  13
            new Vector3(1,-1,-1),    // dir,inf,tras  14
            new Vector3(1,1,-1),     // dir,sup,tras  15
            //encima
            new Vector3(-1,1,-1),    // esq,sup,tras   16
            new Vector3(-1,1,1),     // esq,sup,frente 17
            new Vector3(1,1,-1),     // dir,sup,tras   18
            new Vector3(1,1,1),       // dir,sup,tras   19
            //embaixo
            new Vector3(-1,-1,-1),   // esq,inf,tras   20
            new Vector3(-1,-1,1),    // esq,inf,frente 21
            new Vector3(1,-1,-1),    // dir,inf,tras   22
            new Vector3(1,-1,1)      // dir,inf,tras   23
        };
        mesh.triangles = new int[]
        {
            //frontal
            3,1,0,
            0,2,3,
            //lateral esquerda
            6,4,5,
            5,7,6,
            //lateral direita
            9,8,10,
            10,11,9,
            //atras
            12,13,15,
            15,14,12,
            //cima
            18,16,17,
            17,19,18,
            //baixo
            21,20,22,
            22,23,21

        };
        mesh.colors = new Color[]
        {
            // Frontal
            new Color(1, 0, 0, 1),
            new Color(1, 0, 0, 1),
            new Color(1, 0, 0, 1),
            new Color(1, 0, 0, 1),
            //lateral esquerda
            new Color(0, 1, 0, 1),
            new Color(0, 1, 0, 1),
            new Color(0, 1, 0, 1),
            new Color(0, 1, 0, 1),
            //lateral direita
            new Color(0, 0, 1, 1),
            new Color(0, 0, 1, 1),
            new Color(0, 0, 1, 1),
            new Color(0, 0, 1, 1),
            //atras
            new Color(1, 1, 0, 1),
            new Color(1, 1, 0, 1),
            new Color(1, 1, 0, 1),
            new Color(1, 1, 0, 1),
            //frente
            new Color(0, 1, 1, 1),
            new Color(0, 1, 1, 1),
            new Color(0, 1, 1, 1),
            new Color(0, 1, 1, 1),
            //baixo
            new Color(1, 0, 1, 1),
            new Color(1, 0, 1, 1),
            new Color(1, 0, 1, 1),
            new Color(1, 0, 1, 1)

        };
        gameObject.AddComponent<MeshRenderer>();
        Renderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Custom/ColorShader"));
        
    }

    // Update is called once per frame
    void Update()
    {
      // Rotação no eixo X com as teclas A e D
        float rotationX = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationX * rotationSpeed * Time.deltaTime);

        // Rotação no eixo Y com as teclas W e S
        float rotationY = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * rotationY * rotationSpeed * Time.deltaTime);
    }
}
