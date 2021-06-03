using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Airplane : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    [SerializeField] float paddingX = 1f;
    [SerializeField] float paddingY = 1f;
    [SerializeField] float accelerationTime = 3f;
    [SerializeField] float dccelerationTime = 3f;
    new Rigidbody2D rigidbody;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float moveRotationAngle = 15f;
    Coroutine moveCoroutine;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform muzzle;//枪口位置
    [SerializeField] float fireInterval = 1f;//开火间隔
    WaitForSeconds waitForFireInterval;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.gravityScale = 0f;

        input.EnableGameplayInput();

        waitForFireInterval = new WaitForSeconds(fireInterval / 10f);
    }
    private void OnEnable()
    {
        input.onMove += Move;
        input.onStopMove += StopMove;
        input.onFire += Fire;
        input.onStopFire += StopFire;
    }


    private void OnDisable()
    {
        input.onMove -= Move;
        input.onStopMove -= StopMove;
        input.onFire -= Fire;
        input.onStopFire -= StopFire;
    }


    #region MOVE
    void Move(Vector2 moveInput)
    {
        //Vector2 moveAmount = MoveInput * moveSpeed;
        //rigidbody.velocity = MoveInput * moveSpeed;
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveCoroutine(accelerationTime,
                                                        moveInput.normalized * moveSpeed,
                                                        Quaternion.AngleAxis(moveRotationAngle * moveInput.x * -1f - 90f, Vector3.up)
                                                        )); ;

        StartCoroutine(nameof(MovePositionLimitCoroutine));
    }
    void StopMove()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveCoroutine(dccelerationTime, Vector2.zero, Quaternion.Euler(0f, 270f, 90f)));
        StopCoroutine(nameof(MovePositionLimitCoroutine));
    }
    /// <summary>
    /// 协程，移位限制协程，
    /// </summary>
    /// <returns></returns>
    IEnumerator MovePositionLimitCoroutine()
    {
        while (true)
        {
            transform.position = Viewport.Instance.PlayerMovablePosition(transform.position, paddingX, paddingY);
            yield return null;
        }
    }

    /// <summary>
    /// 协程，进行加减速的Lerp计算
    /// </summary>
    /// <param name="currentSpeed"></param>
    /// <returns></returns>
    IEnumerator MoveCoroutine(float time, Vector2 currentSpeed, Quaternion moveRotation)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.fixedDeltaTime / time;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, currentSpeed, t / time);
            transform.localEulerAngles = new Vector3(0f, Quaternion.Lerp(transform.rotation, moveRotation, t / time).eulerAngles.y, 90f);
            yield return null;
        }
    }
    #endregion

    #region  FIRE
    private void StopFire()
    {
        StopCoroutine(nameof(FireCoroutine));
    }
    private void Fire()
    {
        StartCoroutine(nameof(FireCoroutine));
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            Instantiate(projectile, muzzle.position, Quaternion.identity);
            yield return waitForFireInterval;
        }
    }
    #endregion


}
