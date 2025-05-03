using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    void Start()
    {
        Transformation();
        MaterialSettings();

        StartCoroutine(LetsDie());
    }

    void Transformation()
    {
        transform.parent = GameObject.Find("Terrain_Bullet").transform;
    }

    void MaterialSettings()
    {
        GetComponentInChildren<MeshRenderer>().material = new DataGet().Get_LineMaterial();
    }

    public IEnumerator LetsDie()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(this.gameObject);
    }
}
