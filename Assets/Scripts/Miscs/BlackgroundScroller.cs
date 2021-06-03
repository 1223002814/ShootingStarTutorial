using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackgroundScroller : MonoBehaviour
{
    /// <summary>
    /// 序列化的意思是说再次读取Unity时序列化的变量是有值的，不需要你再次去赋值，因为它已经被保存下来
    /// </summary>
    [SerializeField]Vector2 scrollerVelocity;
    Material material;


    void Awake()
    {
        /// <summary>
        /// 获取渲染器组件，然后取得材质的值
        /// </summary>
        /// <typeparam name="Renderer"></typeparam>
        /// <returns></returns>
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += scrollerVelocity * Time.deltaTime;
    }
}
