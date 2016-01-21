using UnityEngine;
using System.Collections;

public class InterpolateTowards : MonoBehaviour
{
    private bool canInterpolate = false;
    private Vector3 targetPosition;
    private Vector3 targetRotation;

    private void Update()
    {
        if (canInterpolate)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) == 0)
                canInterpolate = false;
        }
    }

    public void BeginInterpolation(Vector3 targetPosition, Vector3 targetRotation)
    {
        this.targetPosition = targetPosition;
        this.targetRotation = targetRotation;

        canInterpolate = true;
    }
}
