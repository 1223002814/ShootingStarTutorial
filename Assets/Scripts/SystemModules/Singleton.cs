using UnityEngine;

public class Singleton<T> : MonoBehaviour where T :Component
{
    public static T Instance { get; private set; }

    /// <summary>
    /// 让派生类重写这函数
    /// </summary>
    protected virtual void Awake() 
    {
        //将类型转化为“T”
        Instance = this as T;
    }
}
