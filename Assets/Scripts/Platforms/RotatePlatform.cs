using UnityEngine;

public class RotatePlatform : MonoBehaviour 
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (((other.gameObject.tag == "Player") && other.GetComponent<CharacterController>().isGrounded))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
