using UnityEngine;

public class exercise1 : MonoBehaviour
{
    private Rigidbody rigibody;
    private Vector3 direction;

    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
    }

    private void FixedUpdate()
    {
        rigibody.linearVelocity = direction;
    }

    private void UpdateDirection()
    {
        float xAxisVelocity = Input.GetAxisRaw("Horizontal");
        float zAxisVelocity = Input.GetAxisRaw("Vertical");
        direction = new Vector3(xAxisVelocity, 0f, zAxisVelocity).normalized;
    }
}
