using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MaskAbilities : MonoBehaviour
{
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
            GameObject.Find("Player").GetComponent<BoxCollider2D>().size = new Vector2(0.35f, 0.3f);
            woodpecker = false;

        }
        else if (woodpecker)
        {
            GameObject.Find("Player").GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 0.6f);
            woodpecker = true;

        }
        else if (cockatoo)
        {
            GameObject.Find("Player").GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 0.6f);
            woodpecker = false;

        }
        else
        {
            GameObject.Find("Player").GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 0.6f);
            woodpecker = false;
        }
    }

}
