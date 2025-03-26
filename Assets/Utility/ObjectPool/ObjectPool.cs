using System;
using System.Collections.Generic;

public interface IPoolable<T> where T : IPoolable<T>
{
    /// <summary>
    /// 오브젝트 생성후 초기화 메서드 
    /// </summary>
    /// <param name="pool">오브젝트가 들어가는 pool</param>
    public void InitObject(ObjectPool<T> pool);

    /// <summary>
    /// 오브젝트 가져왔을때(활성화) 메서드
    /// </summary>
    public void ActiveObject();

    /// <summary>
    /// 오브젝트 반환 메서드
    /// </summary>
    public void ReturnObject();
}

public class ObjectPool<T> where T : IPoolable<T>
{
    private Queue<T> pool;

    public ObjectPool()
    {
        pool = new Queue<T>();
    }

    public bool GetObject(out T obj)
    {
        // pool에 오브젝트가 없을때
        if (!pool.TryDequeue(out obj))
            return false;

        // pool에 오브젝트가 있을때
        obj.ActiveObject();
        return true;
    }

    public void ReturnObject(T obj)
    {
        // 오브젝트 회수
        // pool에 오브젝트 추가
        pool.Enqueue(obj);
    }
}
