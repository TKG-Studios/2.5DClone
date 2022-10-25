using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public Transform movementFrom;
    public Transform movementTo;
    public float speed;
    public float timeCount;

    internal bool isActive = false;
    private void Update()
    {
        if (isActive)
        {
            transform.rotation = Quaternion.Lerp(movementFrom.rotation, movementTo.rotation, timeCount * speed);

        }
    }
}
