using UnityEngine;

public class exercise5 : MonoBehaviour
{
    private Rigidbody rigibody;

    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.X))
        {
            rigibody.AddForce(new Vector3(0f, 0f, -1f));
        }
    }
}
