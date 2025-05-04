using UnityEngine;
using UnityEngine.Assertions.Must;
public class Woodpecker : MonoBehaviour
{
    public Animator animator;
    private bool canDig;
    private GameObject nextSpot;

    [SerializeField] private Transform destination;
    public Masks mask;
    public bool woodpecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


        private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.tag == "Dig Spot" && collision.GetComponent<DigSpot>().nextSpot != null)
        {
            Debug.Log("dig site");
            canDig = true;
            nextSpot = collision.GetComponent<DigSpot>().nextSpot;


        }
        Debug.Log(" Nope");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
        if (collision.tag == "Dig Spot")
        {
            Debug.Log("left Dig site");
            canDig = false;
            nextSpot = null;

        }
         Debug.Log(" Nope");
        }

    



}
   




