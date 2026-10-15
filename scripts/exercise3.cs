using UnityEngine;

public class exercise3 : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color currentColor;
    private int currentDamage;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        currentDamage = 0;
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (IsColorZone(collider))
        {
            SaveCurrentColor();
            UpdateCurrentColorToRandom();
        }
        else if (IsDamageZone(collider))
        {
            IncreaseDamage();
            DisplayDamageIncreaseMessageOnConsole();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (IsColorZone(collider))
        {
            ResetCurrentColor();
        }
    }

    private bool IsColorZone(Collider collider)
    {
        return collider.CompareTag("ColorZone");
    }

    private void SaveCurrentColor()
    {
        currentColor = objectRenderer.material.color;
    }

    private void UpdateCurrentColorToRandom()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        objectRenderer.material.color = new Color(r, g, b);
    }

    private bool IsDamageZone(Collider collider)
    {
        return collider.CompareTag("DamageZone");
    }

    private void DisplayDamageIncreaseMessageOnConsole()
    {
        Debug.Log("Damage increase: " + currentDamage);
    }

    private void IncreaseDamage() 
    {
        currentDamage++;
    }

    private void ResetCurrentColor()
    {
        objectRenderer.material.color = currentColor;
    }
}
