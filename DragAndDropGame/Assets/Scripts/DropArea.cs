using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public Transform DropTransform;

    public void TransformMoveOnY() {
        // DropTransform.position += Vector3.up * 0.01f;
        DropTransform.localPosition += Vector3.up * 0.01f;
    }
}
