using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerProjectilePools;

    private void Start() {
        Init(playerProjectilePools);
    }
    private void Init(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            Transform poolParent =  new GameObject("Pool: " + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Init(poolParent);
        }
    }
}
