using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject Prefab { get => prefab; }
    [SerializeField] GameObject prefab;
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
    private GameObject CreatePreparedObject()
    {
        var preparedObject = GameObject.Instantiate(prefab, parent);
        preparedObject.SetActive(false);
        return preparedObject;
    }
    /// <summary>
    /// 从对象池中取出对象
    /// </summary>
    /// <returns></returns>
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
    public GameObject PreparedObject()
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        return preparedObject;
    }
    public GameObject PreparedObject(Vector3 position)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        return preparedObject;
    }
    public GameObject PreparedObject(Vector3 position, Quaternion rotation)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        return preparedObject;
    }
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
