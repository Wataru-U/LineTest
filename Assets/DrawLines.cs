using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    // 頂点のリスト
    private List<Vector3> vertices;

    // 結ぶ頂点のインデックスのリスト　長さは偶数
    // 描画する際に配列に直すのであらかじめ長さが分かっている場合は配列でも可
    private List<int> indexes;
    private Material _material;
    private Mesh _mesh;
    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>();
        indexes = new List<int>();
        _mesh = GetComponent<MeshFilter>().mesh;
        //とりあえず原点と(0,1,0)をつなく線
        vertices.Add(new Vector3(0,0,0));
        vertices.Add(new Vector3(0,1,0));

        //verticesリストの　０番目と１番目　を繋ぐ
        indexes.Add(0);
        indexes.Add(1);

    }

    void Update()
    {
        drawLine();
    }

    void drawLine()
    {
        _mesh.SetVertices(vertices);
        _mesh.SetIndices(indexes.ToArray(), MeshTopology.Lines, 0);
        Graphics.DrawMesh(_mesh, transform.position, Quaternion.identity, _material, 0);
    }
}
