using UnityEngine;
using Random = UnityEngine.Random;

public class RedCube : MonoBehaviour, IPoolable<RedCube>
{
    float posX;
    float posY;
    float posZ;

    private ObjectPool<RedCube> pool;

    public void InitObject(ObjectPool<RedCube> pool)
    {
        this.pool = pool;
    }

    public void ActiveObject()
    {
        gameObject.SetActive(true);
    }

    public void ReturnObject()
    {
        pool.ReturnObject(this); // 오브젝트 반환

        // 비활성화
        gameObject.SetActive(false);
    }

    public void NewPosition()
    {
        posX = Random.Range(-10, 10);
        posY = Random.Range(-10, 10);
        posZ = Random.Range(-10, 10);
    }

    public void SpawnCube()
    {
        NewPosition();
        transform.position = new Vector3(posX, posY, posZ);

        Invoke("ReturnObject", 2f);
    }
}
