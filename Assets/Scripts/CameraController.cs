using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _pivot;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _maxViewAngle;
    [SerializeField] private float _minViewAngle;

    private void Start()
    {
        _offset = _target.position - transform.position;

        _pivot.transform.position = _target.transform.position;
        //_pivot.transform.parent = _target.transform;
        _pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        _pivot.transform.position = _target.transform.position;

        //Get the X position of the mouse and otate the target
        float horizontal = Input.GetAxis("Mouse X") * _rotateSpeed;
        _pivot.Rotate(0, horizontal, 0);

        //Get the Y position of the mouse and rotate the pivot
        //float vertical = Input.GetAxis("Mouse Y") * _rotateSpeed;
        //_pivot.Rotate(-vertical, 0, 0);

        //Limit up/down camera rotation
        if (_pivot.rotation.eulerAngles.x > _maxViewAngle && _pivot.rotation.eulerAngles.x < 180.0f)
        {
            _pivot.rotation = Quaternion.Euler(_maxViewAngle, _pivot.eulerAngles.y, 0.0f);
        }

        //if (_pivot.rotation.eulerAngles.x > 180.0f && _pivot.rotation.eulerAngles.x < 360f + _minViewAngle)
        //{
        //    _pivot.rotation = Quaternion.Euler(360.0f + _minViewAngle, _pivot.eulerAngles.y, 0.0f);
        //}

        //Move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = _pivot.eulerAngles.y;
        float desiredXAngle = _pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = _target.position - (rotation * _offset);

        //transform.position = _target.position - _offset;

        if (transform.position.y < _target.position.y)
        {
            transform.position = new Vector3(transform.position.x, _target.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(_target);
    }
}
