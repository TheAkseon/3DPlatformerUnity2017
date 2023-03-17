using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Update()
    {
        Destroy(gameObject, _lifeTime);
    }
}
