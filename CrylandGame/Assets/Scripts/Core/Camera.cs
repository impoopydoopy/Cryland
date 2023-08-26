using System;
using UnityEngine.UI;
using UnityEngine;

public sealed class Camera : MonoBehaviour
{

    public enum MovementType { Set, Follow, Ahead }

    public Transform target;

    // parameters
    public MovementType movementType;
    public float smoothFactor;
    public float aheadFactor;
    public float minTeleportDistance;

    // cache
    private static Vector2 _lastTargetPos;
    private static Vector2 _velocity;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector2 targetPos = target.position;
        Vector2 cameraTargetPos = targetPos;
        if (movementType == MovementType.Ahead)
        {
            cameraTargetPos += (targetPos - _lastTargetPos).normalized * aheadFactor;
        }

        Vector3 resPos = movementType == MovementType.Set || Vector2.Distance(_lastTargetPos, targetPos) >= minTeleportDistance
            ? cameraTargetPos
            : Vector2.SmoothDamp(transform.position, cameraTargetPos, ref _velocity, smoothFactor);
        resPos.z = -10f;
        transform.position = resPos;
        _lastTargetPos = targetPos;
    }
}