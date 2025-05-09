using UnityEngine;
using UnityEngine.SceneManagement;
public class END : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object that should trigger the scene change
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mainmenu");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
