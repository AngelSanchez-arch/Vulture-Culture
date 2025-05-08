using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MaskAbilities : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float newWidth;
    public float newHeight;
    public Masks mask;
    public bool titmouse;
    public bool woodpecker;
    public bool cockatoo;

    public void Start()
    {
        //mask = GetComponent<Masks>();
    }

    public void Update()
    {
        if (titmouse)
        {
            GameObject.Find("Player").transform.localScale = new Vector2(0.35f, 0.3f);
            titmouse = true;
            woodpecker = false;
            cockatoo = false;
        }
        else if (woodpecker)
        {
            GameObject.Find("Player").transform.localScale = new Vector2(0.6f, 0.6f);
            woodpecker = true;
            cockatoo=false;
            titmouse = false;
        }
        else if (cockatoo)
        {
            GameObject.Find("Player").transform.localScale = new Vector2(0.6f, 0.6f);
            woodpecker = false;
            cockatoo = true;
            titmouse = false;
        }
        else
        {
            GameObject.Find("Player").transform.localScale = new Vector2(0.6f, 0.6f);
            woodpecker = false;
            cockatoo = false;
            titmouse = false;
        }
        
        if (woodpecker == true)
        {
            FindFirstObjectByType<Woodpecker>().enabled = true;
        }
        if (woodpecker == false)
        {
            FindFirstObjectByType<Woodpecker>().enabled = false;
        }
        if (titmouse == true)
        {
            FindFirstObjectByType<Titmouse>().enabled = true;
        }
        if (titmouse == false)
        {
            FindFirstObjectByType<Titmouse>().enabled = false;
        }
        if (cockatoo == true)
        {
            FindFirstObjectByType<Coctatoo>().enabled = true;
        }
        if (cockatoo == false)
        {
            FindFirstObjectByType<Coctatoo>().enabled = false;
        }
    }

}
