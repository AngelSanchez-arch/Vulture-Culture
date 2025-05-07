using UnityEngine;

 public class Titmouse : MonoBehaviour
{
 
    public Animator animator;
    public Masks mask;
    public bool titmouse;
    public float newWidth;
    public float newHeight;
    public float oldWidth;
    public float oldHeight;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not assigned in SpriteSizeChanger script");
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (titmouse == true)
        {
            //spriteRenderer.size = new Vector2(newWidth, newHeight);

            //transform.localScale = new(0.5f, 0.5f);
        }

        else
        {
            //spriteRenderer.size = new Vector2(oldWidth, oldHeight);
            //transform.localScale = new(1.0f, 1.0f);
        }
     }
    
}
