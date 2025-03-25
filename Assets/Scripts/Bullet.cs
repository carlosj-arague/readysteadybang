using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {

        transform.Rotate(new Vector3(90, 0,0));

        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.zero - new Vector3(0,0,transform.position.z) * 10, ForceMode.VelocityChange);

        Invoke("DestroyBullet", 5);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        
        other.SendMessage("CharacterFall");
        DestroyBullet();
    }
}
