using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{

    public GameObject Cube;
    public List<Vector3> placements;
    private Vector3 newPlacement;

    void Start()
    {
        int x;
        int z;

        for (int i = 1; i <= 10; i++)
        {
            x = Random.Range(-4, 4);
            z = Random.Range(-4, 4);
            newPlacement = new Vector3(x, transform.position.y + 0.25f, z);

            while (placements.Contains(new Vector3(x, transform.position.y, z)))
            {
                x = Random.Range(-4, 4);
                z = Random.Range(-4, 4);
                newPlacement = new Vector3(x, transform.position.y, z);
            }

            placements.Add(newPlacement);
            Instantiate(Cube, newPlacement, Quaternion.identity);
        }
    }
    void Update()
    {

    }
}