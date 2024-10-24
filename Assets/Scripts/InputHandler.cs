using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] Player player;
    void Update()
    {
        player.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetMouseButtonDown(0))
            player.Shoot(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
