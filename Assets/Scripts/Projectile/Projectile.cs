using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Vector2 moveDirectly;

    private void OnEnable()
    {
        StartCoroutine(nameof(MoveDirectly));
    }
    IEnumerator MoveDirectly()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(moveSpeed * moveDirectly * Time.deltaTime);
            yield return null;
        }
    }
}
