using UnityEngine;

public class exercise6 : MonoBehaviour
{
    private GameObject cubeObstacle;
    private GameObject cylinderTarget;
    private Collider sphereCollider;
    private Collider cubeCollider;
    private Material currentCubeMaterial;
    private Material newCubeMaterial;
    private bool hasReachedCylinderTarget;
    private bool isCollidingWithCubeObject;

    void Start()
    {
        cubeObstacle = GameObject.FindWithTag("CubeObstacle");
        cylinderTarget = GameObject.FindWithTag("CylinderTarget");
        sphereCollider = GetComponent<Collider>();
        cubeCollider = cubeObstacle.GetComponent<Collider>();
        currentCubeMaterial = cubeObstacle.GetComponent<Renderer>().material;
        newCubeMaterial = Resources.Load<Material>("Materials/NewMaterial");
        hasReachedCylinderTarget = false;
        isCollidingWithCubeObject = false;
    }

    void Update()
    {
        if (!hasReachedCylinderTarget)
        {
            MoveToCylinder();
            IfItsCollidingWithCubeObstacleChangeCubeMaterial();
        }
    }

    private void MoveToCylinder()
    {
        Transform cylinderTransform = cylinderTarget.transform;
        transform.LookAt(cylinderTransform);
        Vector3 displacement = Vector3.forward * Time.deltaTime;
        transform.Translate(displacement, Space.Self);
        if (Vector3.Distance(transform.position, 
            cylinderTransform.position) < 0.1f)
        {
            hasReachedCylinderTarget = true;
        }
    }

    private void IfItsCollidingWithCubeObstacleChangeCubeMaterial()
    {
        if (sphereCollider.bounds.Intersects(cubeCollider.bounds))
        {
            if (!isCollidingWithCubeObject)
            {
                Renderer cubeRenderer = cubeObstacle.GetComponent<Renderer>();
                cubeRenderer.material = newCubeMaterial;
                isCollidingWithCubeObject = true;
            }
        } 
        else 
        {
            if (isCollidingWithCubeObject)
            {
                Renderer cubeRenderer = cubeObstacle.GetComponent<Renderer>();
                cubeRenderer.material = currentCubeMaterial;
                isCollidingWithCubeObject = false;
            }
        }
    }
}