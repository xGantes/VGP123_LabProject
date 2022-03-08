using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minXClamp = 0.44f;
    public float maxXClamp = 36.14f;

    private void LateUpdate()
    {
        if(GameManager.instances.playerInstances)
        {
            Vector3 camTransform = transform.position;
            camTransform.x = GameManager.instances.playerInstances.transform.position.x;
            camTransform.x = Mathf.Clamp(camTransform.x, minXClamp, maxXClamp);
            transform.position = camTransform;
        }
    }
}
