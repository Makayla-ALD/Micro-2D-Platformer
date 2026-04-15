using System.Collections;
using UnityEngine;

public sealed class Goomba : MonoBehaviour
{
    [Header("Local Offsets")]
    public Vector2 pointA = new Vector2(-2f, 0f);
    public Vector2 pointB = new Vector2(2f, 0f);

    [Header("Movement")]
    public float speed = 2f;
    public float pauseTime = 1f;

    private bool goingToB = true;
    private bool isPaused;

    private Vector3 startLocalPos;

    void Start()
    {
        // gets the position of the enemy
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        if (isPaused) return;

        Vector3 targetOffset = goingToB ? pointB : (Vector3)pointA;
        Vector3 target = startLocalPos + targetOffset;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.localPosition, target) < 0.01f)
        {
            StartCoroutine(PauseAndSwitch());
        }
    }

    IEnumerator PauseAndSwitch()
    {
        isPaused = true;
        OnPause();

        yield return new WaitForSeconds(pauseTime);

        goingToB = !goingToB;
        isPaused = false;

        OnResume();
    }

    private void OnPause()
    {
        // He do a lil dance code
    }

    private void OnResume()
    {
        // Stop dance code
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 basePos = Application.isPlaying ? startLocalPos : transform.localPosition;

        Vector3 worldA = transform.parent ? transform.parent.TransformPoint(basePos + (Vector3)pointA) : basePos + (Vector3)pointA;
        Vector3 worldB = transform.parent ? transform.parent.TransformPoint(basePos + (Vector3)pointB) : basePos + (Vector3)pointB;

        Gizmos.DrawSphere(worldA, 0.2f);
        Gizmos.DrawSphere(worldB, 0.2f);
        Gizmos.DrawLine(worldA, worldB);
    }
}