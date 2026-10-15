using UnityEngine;

public class exercise2 : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision) 
    {
        DisplayCollisionGameObjectNameOnConsole(collision.gameObject.name);
        UpdateCurrentColorToRandom();
    }

    private void UpdateCurrentColorToRandom()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        objectRenderer.material.color = new Color(r, g, b);
    }

    private void DisplayCollisionGameObjectNameOnConsole(string name)
    {
        Debug.Log("Collision with: " + name);
    }
}
