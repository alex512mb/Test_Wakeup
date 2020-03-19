using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovingByPlayerInput : MonoBehaviour
{
    [SerializeField]
    protected float speed = 3;


    private CharacterController characterController;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
    }


    private void Move(Vector3 direction)
    {
        characterController.Move(direction.normalized * speed * Time.deltaTime);
        transform.LookAt(transform.position + direction);
    }
}
