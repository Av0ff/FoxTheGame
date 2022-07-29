using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Collider _prevCollider;

    private Camera _cameraMain;

    [SerializeField]
    private InfoPanel _panel;

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private Fox _character;

    private void Awake()
    {
        _cameraMain = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = _cameraMain.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.GetComponent<Outline>())
                    {
                        hit.collider.GetComponent<Outline>().OutlineWidth = 3;
                        _prevCollider = hit.collider;

                        AddInteractable();
                    }
                }
                if (_prevCollider != null)
                {
                    SetupFunctionalityJoint();

                    Vector3 camNull = _cameraMain.transform.InverseTransformPoint(0, 0, 0);
                    _target.transform.position = _cameraMain.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camNull.z));

                    HealhRepair();
                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(_prevCollider != null)
            {
                Destroy(_prevCollider.GetComponent<HingeJoint>());
                _prevCollider.GetComponent<Outline>().OutlineWidth = 0;
                _prevCollider.transform.localPosition = Vector3.zero;
                _prevCollider.GetComponent<Rigidbody>().isKinematic = true;
                _prevCollider = null;
            }
        }
    }

    private void AddInteractable()
    {
        if (!_prevCollider.GetComponent<HingeJoint>()) _prevCollider.gameObject.AddComponent<HingeJoint>();
        _prevCollider.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void SetupFunctionalityJoint()
    {
        JointSpring hingeSpring;
        hingeSpring.spring = 100f;
        hingeSpring.damper = 5f;
        hingeSpring.targetPosition = 0;

        if (_prevCollider.TryGetComponent<HingeJoint>(out HingeJoint hingeJoint))
        {
            var joint = hingeJoint.GetComponent<HingeJoint>();
            joint.connectedBody = _target.GetComponent<Rigidbody>();
            joint.autoConfigureConnectedAnchor = false;
            joint.anchor = Vector3.up;
            joint.axis = -Vector3.forward;
            joint.useSpring = true;
            joint.spring = hingeSpring;

        }
    }

    private void HealhRepair() //нужно будет исправить
    {
        if(_character.Health != 10)
        {
            Vector3 distance = _character.transform.position - _prevCollider.transform.position;
            if (distance.magnitude < 8f)
            {
                Destroy(_prevCollider.gameObject);
                DontDestroyOnLoadLevel.Load.Food--;
                _character.Health++;
            }
        }
    }
}
