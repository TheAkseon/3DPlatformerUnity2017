using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddGold(value);

            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
