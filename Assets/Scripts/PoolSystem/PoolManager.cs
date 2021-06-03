using System.Drawing;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] objectPools;
    private static Dictionary<GameObject, Pool> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<GameObject, Pool>();
        Init(objectPools);
    }
    /// <summary>
    /// <para>根据传入的<paramref name="pools"></paramref>对象池数组，初始化对象池。</para>
    /// </summary>
    /// <param name="pools"></param>
    private void Init(Pool[] pools)
    {
        foreach (var pool in pools)
        {
#if UNITY_EDITOR
            if (poolDictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("Same Prefab in multiple pools!! Pool: " + pool.Prefab.name);
                continue;
            }
#endif
            poolDictionary.Add(pool.Prefab, pool);
            Transform poolParent = new GameObject("Pool: " + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Init(poolParent);
        }
    }

    /// <summary>
    /// <para>Return a specified<paramref name="prefab"></paramref>gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中准备好的游戏对象。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <returns>
    /// <para>Prepared gameObject in the pool.</para>
    /// <para>对象池中预备好的游戏对象。</para>
    /// </returns>
    public static GameObject Release(GameObject prefab)
    {
#if UNITY_EDITOR
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return poolDictionary[prefab].PreparedObject();
    }
    /// <summary>
    /// <para>Return a specified<paramref name="prefab"></paramref>gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中准备好的游戏对象，并设置其<paramref name="position"></paramref>。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <returns>
    /// <para>Prepared gameObject in the pool.</para>
    /// <para>对象池中预备好的游戏对象。</para>
    /// </returns>
    public static GameObject Release(GameObject prefab, Vector3 position)
    {
#if UNITY_EDITOR
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return poolDictionary[prefab].PreparedObject(position);
    }
    /// <summary>
    /// <para>Return a specified<paramref name="prefab"></paramref>gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中准备好的游戏对象，并设置其
    /// <paramref name="position"></paramref>,
    /// <paramref name="rotation"></paramref>。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <returns>
    /// <para>Prepared gameObject in the pool.</para>
    /// <para>对象池中预备好的游戏对象。</para>
    /// </returns>
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation)
    {
#if UNITY_EDITOR
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return poolDictionary[prefab].PreparedObject(position, rotation);
    }
    /// <summary>
    /// <para>Return a specified<paramref name="prefab"></paramref>gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中准备好的游戏对象，并设置其
    /// <paramref name="position"></paramref>,
    /// <paramref name="rotation"></paramref>，
    /// <paramref name="localScale"></paramref>。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <returns>
    /// <para>Prepared gameObject in the pool.</para>
    /// <para>对象池中预备好的游戏对象。</para>
    /// </returns>
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale)
    {
#if UNITY_EDITOR
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return poolDictionary[prefab].PreparedObject(position, rotation, localScale);
    }
}
