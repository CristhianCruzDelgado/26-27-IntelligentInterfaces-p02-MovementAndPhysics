using UnityEngine;

public class exercise6 : MonoBehaviour
{
    public Transform cylinderTransform;
    public GameObject cubeObstacle;
    public Material newCubeMaterial;

    private Collider sphereCollider;
    private Collider cubeCollider;
    private bool hasReachedTarget = false;
    private bool materialChanged = false;

    void Start()
    {
        sphereCollider = GetComponent<Collider>();
        cubeCollider = cubeObstacle.GetComponent<Collider>();
    }

    void Update()
    {
        if (!hasReachedTarget)
        {
            MoveToCylinder();
            CheckColliderIntersection();
        }
    }

    private void MoveToCylinder()
    {
        transform.LookAt(cylinderTransform);
        Vector3 displacement = Vector3.forward * Time.deltaTime;
        transform.Translate(displacement, Space.Self);
        if (Vector3.Distance(transform.position, cylinderTransform.position) < 0.1f)
        {
            hasReachedTarget = true;
        }
    }

    private void CheckColliderIntersection()
    {
        if (!materialChanged)
        {
            if (sphereCollider.bounds.Intersects(cubeCollider.bounds))
            {
                ChangeCubeMaterial();
                materialChanged = true;
            }
        }
    }

    private void ChangeCubeMaterial()
    {
        Renderer cubeRenderer = cubeObstacle.GetComponent<Renderer>();
        cubeRenderer.material = newCubeMaterial;
    }
}
