using UnityEngine;

// Based on: https://www.sharpcoderblog.com/blog/drag-rigidbody-with-mouse-cursor-unity-3d-tutorial

public class SC_DragRigidbody : MonoBehaviour
{
    [SerializeField] private float _forceAmount = 500;

    private Rigidbody _selectedRigidbody;
    private Camera _targetCamera;
    private Vector3 _originalScreenTargetPosition;
    private Vector3 _originalRigidbodyPos;
    private float _selectionDistance;

    // Start is called before the first frame update
    void Start()
    {
        _targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!_targetCamera)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            //Check if we are hovering over Rigidbody, if so, select it
            _selectedRigidbody = GetRigidbodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0) && _selectedRigidbody)
        {
            //Release selected Rigidbody if there any
            _selectedRigidbody = null;
        }
    }

    void FixedUpdate()
    {
        if (_selectedRigidbody)
        {
            Vector3 mousePositionOffset = _targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectionDistance)) - _originalScreenTargetPosition;
            Vector3 newVelocity = (_originalRigidbodyPos + mousePositionOffset - _selectedRigidbody.transform.position) * _forceAmount * Time.deltaTime;
            newVelocity.z = 0.0f;
            _selectedRigidbody.linearVelocity = newVelocity;
        }
    }

    Rigidbody GetRigidbodyFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = _targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                _selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                _originalScreenTargetPosition = _targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectionDistance));
                _originalRigidbodyPos = hitInfo.collider.transform.position;
                return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            }
        }

        return null;
    }
}