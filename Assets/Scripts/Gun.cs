using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void Shoot()
    {
        GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
