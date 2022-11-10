using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int objectCount = 10;
    GameObject gObject;

    // obiekt do generowania
    public GameObject block;
    public List<Material> materials = new List<Material>();

    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        // skrajne koordynaty x i z
        int planeWidth = (int)(renderer.bounds.size.x / 2);
        int planeDepth = (int)(renderer.bounds.size.z / 2);

        int maxObjects = Math.Min(planeDepth * 2, planeWidth * 2);
        objectCount = objectCount > maxObjects ? maxObjects : objectCount;

        List<int> pozycje_x = new List<int>(Enumerable.Range(-planeWidth, planeWidth * 2).OrderBy(x => Guid.NewGuid()).Take(objectCount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(-planeDepth, planeDepth * 2).OrderBy(x => Guid.NewGuid()).Take(objectCount));

        for (int i = 0; i < objectCount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 2, pozycje_z[i]));
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {

            GameObject go = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity) as GameObject;
            int random = UnityEngine.Random.Range(0, materials.Count());
            go.GetComponent<MeshRenderer>().material = materials[random];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}