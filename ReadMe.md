# Unityで線の描画

* ## 必要なコンポーネント
    * スクリプト
    * MeshFilter
    * MeshRenderer
    * Material(色を変えたいときはなくても可)

* ## 1.コード(C#)
上記のコンポーネントとこのコードを書くことで画面の中心に縦に赤紫の線が描画されるはず

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    // 頂点のリスト
    private List<Vector3> vertics;

    // 結ぶ頂点のインデックスのリスト　長さは偶数
    // 描画する際に配列に直すのであらかじめ長さが分かっている場合は配列でも可
    private List<int> indexes;
    private Material _material;
    private Mesh _mesh;
    // Start is called before the first frame update
    void Start()
    {
        vertics = new List<Vector3>();
        indexes = new List<int>();
        _mesh = GetComponent<MeshFilter>().mesh;

        //とりあえず原点と(0,1,0)をつなく線
        vertics.Add(new Vector3(0,0,0));
        vertics.Add(new Vector3(0,1,0));

        //verticsリストの　０番目と１番目　を繋ぐ
        indexes.Add(0);
        indexes.Add(1);

    }

    void Update()
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
```

* ## 2.好きな座標に線を描画する
veticsとindexesを変更することで好きなところに描画できる.
<br>
indexesにはverticsに入れた頂点と対応するインデックスを入れる。
線の始点と終点の2つでセット。
<br>   
    例）
 * verticsの0,1,2,3の順に線を引きたい場合
```
    indexes = new List<int>(){0,1, 1,2, 2,3};
```
 * 0,1 と　3,4  の2本を引きたい場合
 ```
    indexes = new List<int>(){0,1, 3,4};
 ```

 ### リストの追加
    .add(入れるもの)
    .addRange(入れるリスト)

* ## 3.線の色を変える