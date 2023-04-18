using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _pivot;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = _target.position - transform.position;

        _pivot.transform.position = _target.transform.position;
        _pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        _pivot.transform.position = _target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * _rotateSpeed;
        _pivot.Rotate(0, horizontal, 0);

        float desiredYAngle = _pivot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        transform.position = _target.position - (rotation * _offset);

        transform.LookAt(_target);
    }
}
