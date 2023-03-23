using UnityEngine;

public class VerticalPlatform : MonoBehaviour 
{
    [SerializeField] private int _amplitude = 1;
    [SerializeField] private float _frequency = 0.1f;

    private void Update()
    {
        float x = transform.position.x;
        float y = Mathf.Cos(Time.time * _frequency) * _amplitude;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }

    private void OnTriggerStay(Collider other)
    {
        if(((other.gameObject.tag == "Player") && other.GetComponent<CharacterController>().isGrounded) || other.gameObject.tag == "Coin")
        {
            other.transform.parent = transform;
        }
    } 

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
