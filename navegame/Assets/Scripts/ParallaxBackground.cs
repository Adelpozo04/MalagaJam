using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // Scroll the main texture based on time

    [SerializeField] float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
