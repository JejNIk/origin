
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerControl : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lookspeed = 5f;
    PlayerMotor motor;
	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 MoveHorizontal = transform.right * xMove;
        Vector3 MoveVertical = transform.forward * zMove;
        Vector3 velocity = (MoveHorizontal + MoveVertical).normalized * speed;
        motor.Move(velocity);
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 Rotation = new Vector3(0f, yRot, 0f)*lookspeed;
        motor.Rotate(Rotation);
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f)*lookspeed ;
        motor.camRotate(-camRotation);
    }
}
