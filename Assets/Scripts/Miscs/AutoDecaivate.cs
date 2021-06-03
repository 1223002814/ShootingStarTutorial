using System.Collections;
using UnityEngine;

public class AutoDecaivate : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    [SerializeField] bool isDestroyGameObject;
    WaitForSeconds waitLifeTime;

    private void Awake()
    {
        waitLifeTime = new WaitForSeconds(lifeTime);
    }
    private void OnEnable() {
        StartCoroutine(nameof(DeactivateCorouatine));
    }
    IEnumerator DeactivateCorouatine()
    {
            yield return waitLifeTime;

            if(isDestroyGameObject)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
    }
}
