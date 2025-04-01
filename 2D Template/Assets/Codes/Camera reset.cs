using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    private int offset;

    private CinemachineFollow follow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        follow = GetComponent<CinemachineFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.
    }
    public void Movecamera(InputAction.CallbackContext ctx, int pos)
    {
        Vector2 amount = ctx.ReadValue<Vector2>();
        (int, int, int) Pos = (0, 0, -10);
        offset = pos;
    }
}
