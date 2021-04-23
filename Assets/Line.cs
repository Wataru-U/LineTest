using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // 頂点のリスト
    private List<Vector3> vertics;
    // 結ぶ頂点のインデックスのリスト　長さは偶数
    // 描画する際に配列に直すのであらかじめ長さが分かっている場合は配列でも可
    private List<int> indexes;
    private Material _material;
    private Mesh _mesh;

    void start()
    {
        Debug.Log("Hoge");
        vertics = new List<Vector3>();
        indexes = new List<int>();
        _mesh = GetComponent<MeshFilter>().mesh;
        _material = GetComponent<Material>();
        //とりあえず原点と(0,1,0)をつなく線
        vertics.Add(new Vector3(0,0,0));
        vertics.Add(new Vector3(0,1,0));

        //verticsリストの　０番目と１番目　を繋ぐ
        indexes.Add(0);
        indexes.Add(1);

        Debug.Log(vertics.Count);
        Debug.Log(indexes.Count);
    }

    void update()
    {
        drawLine();
    }

    void drawLine()
    {
        _mesh.SetVertices(vertics);
        _mesh.SetIndices(indexes.ToArray(), MeshTopology.Lines, 0);
        Graphics.DrawMesh(_mesh, transform.position, Quaternion.identity, _material, 0);
    }
}
