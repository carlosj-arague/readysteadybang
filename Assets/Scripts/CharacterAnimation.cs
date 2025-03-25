using UnityEngine;

public class CharacterAction : MonoBehaviour
{

    Transform GunArm;

    Quaternion OriginalRotation;
    Quaternion GunArmOriginalRotation;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponentInChildren<Gun>() != null)
            {
                GunArm = child;
            }
        }

        OriginalRotation = transform.rotation;
        GunArmOriginalRotation = GunArm.rotation;
    }

    public void CharacterShoot()
    {
        GunArm.Rotate(new Vector3(-60, 0, 0));
        GunArm.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        GunArm.GetComponentInChildren<Gun>().Shoot();
    }

    public void CharacterResetPosition()
    {

        transform.rotation = OriginalRotation;
        GunArm.rotation = GunArmOriginalRotation;
        GunArm.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        /*
        if (transform.rotation.x != 0)
        {
            transform.Rotate(new Vector3(90, 0, 0));
        } else
        {
            Debug.Log(transform.rotation.x + " --- " + GunArm.rotation.x);
        }

        if (GunArm.rotation.x != 0)
        {
            GunArm.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            GunArm.Rotate(new Vector3(60, 0, 0));
        }*/

    }

    public void CharacterFall()
    {
        transform.Rotate(new Vector3(-90, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        CharacterFall();
    }
}
