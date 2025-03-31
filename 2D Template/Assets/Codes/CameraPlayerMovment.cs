using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraPlayerMovment : MonoBehaviour
{
    public float Scrollspeed;
    private CinemachineFollow follow;
    private Vector2 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        follow = GetComponent<CinemachineFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        follow.FollowOffset.x += offset.x;
        follow.FollowOffset.y += offset.y;
    }

    public void Movecamera(InputAction.CallbackContext ctx)
    {
        Vector2 amount = ctx.ReadValue<Vector2>();
        offset = amount * Scrollspeed;
    }
}
