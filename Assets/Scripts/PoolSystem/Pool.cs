using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject Prefab { get => prefab; }
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 1;
    private Queue<GameObject> queue;
    private Transform parent;

    public void Init(Transform parent)
    {
        this.parent = parent;
        queue = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            queue.Enqueue(CreatePreparedObject());
        }
    }
    /// <summary>
    /// 创建空闲的游戏对象。
    /// </summary>
    /// <returns></returns>
    private GameObject CreatePreparedObject()
    {
        var preparedObject = GameObject.Instantiate(prefab, parent);
        preparedObject.SetActive(false);
        return preparedObject;
    }
    /// <summary>
    /// 从对象池中取出不在使用的游戏对象。
    /// </summary>
    /// <returns>
    /// <para>对象池中空闲的游戏对象。</para>
    /// </returns>
    private GameObject AvailableObject()
    {
        GameObject availableObject = null;
        if (queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = CreatePreparedObject();
        }
        queue.Enqueue(availableObject);
        return availableObject;
    }
    /// <summary>
    /// 取得已激活的可用游戏对象。
    /// </summary>
    /// <returns>
    /// <para>返回已激活的可用游戏对象。</para>
    /// </returns>
    public GameObject PreparedObject()
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        return preparedObject;
    }
    /// <summary>
    /// 取得已激活的可用游戏对象，并设置其<paramref name="position"></paramref>。
    /// </summary>
    /// <param name="position"></param>
    /// <returns>
    /// <para>返回已激活的可用游戏对象。</para>
    /// </returns>
    public GameObject PreparedObject(Vector3 position)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        return preparedObject;
    }
    /// <summary>
    /// 取得已激活的可用游戏对象，并设置其<paramref name="position"></paramref>，<paramref name="rotation"></paramref>。
    /// </summary>
    /// <param name="position"></param>
    /// <returns>
    /// <para>返回已激活的可用游戏对象。</para>
    /// </returns>
    public GameObject PreparedObject(Vector3 position, Quaternion rotation)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        return preparedObject;
    }
    /// <summary>
    /// 取得已激活的可用游戏对象，并设置其<paramref name="position"></paramref>，<paramref name="rotation"></paramref>，<paramref name="localScale"></paramref>。
    /// </summary>
    /// <param name="position"></param>
    /// <returns>
    /// <para>返回已激活的可用游戏对象。</para>
    /// </returns>
    public GameObject PreparedObject(Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        preparedObject.transform.localScale = localScale;
        return preparedObject;
    }

}
