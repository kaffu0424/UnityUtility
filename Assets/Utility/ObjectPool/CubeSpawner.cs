using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private ObjectPool<RedCube> pool;
    [SerializeField] private GameObject redCubePrefab;

    private void Start()
    {
        pool = new ObjectPool<RedCube>();
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        yield return null;

        while (true)
        {
            if(!pool.GetObject(out RedCube cube))
            {
                cube = Instantiate(redCubePrefab).GetComponent<RedCube>(); 
                cube.InitObject(pool);
            }

            cube.SpawnCube();

            yield return new WaitForSeconds(1f);
        }
    }
}
