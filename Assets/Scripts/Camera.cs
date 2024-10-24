using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float Speed;
    Vector3 pos;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        pos = (UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) + Player.position) / 2;
        pos = (Player.position + 3 * pos) / 4;
        pos -= transform.position;
        pos.z = 0f;
        transform.position += Speed * Time.deltaTime * pos;
        //transform.Translate(Speed * Time.deltaTime * pos);
    }
}
