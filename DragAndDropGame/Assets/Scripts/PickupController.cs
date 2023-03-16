using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;
using DG.Tweening;

public class PickupController : MonoBehaviour
{
    bool isPicked = false;
    [SerializeField] Transform PickTransform;
    [SerializeField] float Radius;
    Collider[] Cols;
    [SerializeField] LayerMask LayerMask;
    GameObject _PickedItem;
    HingeJoint hj;
    void Start()
    {
        hj = PickTransform.GetComponent<HingeJoint>();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(PickTransform.position, Radius);
        Gizmos.color = new Color(0.4f,0,0,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Cols = Physics.OverlapSphere(PickTransform.position, Radius, LayerMask);
        foreach (Collider item in Cols)
        {
            if (!isPicked) {
                isPicked = true;
                _PickedItem = item.gameObject;
                Debug.Log(_PickedItem.name);
                Rigidbody itemRb = item.GetComponent<Rigidbody>();
                hj.connectedBody = itemRb;
                GetComponent<PlayerController>().SwitchMove();
                GetComponent<AnimatorIKDemo>().SwitchActive();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("DropArea") && isPicked) {
            hj.connectedBody = null;
            GetComponent<AnimatorIKDemo>().SwitchActive();
            DropArea DA = other.GetComponent<DropArea>();
            Transform DTrans = DA.DropTransform;
            GetComponent<PlayerController>().SwitchMove();

            _PickedItem.transform.DOJump(DTrans.position, 10, 1, 0.75f).OnComplete(() => {
                _PickedItem.layer = 0;
                isPicked = false;
                _PickedItem = null;
                DA.TransformMoveOnY();
            });

        }
    }
}
