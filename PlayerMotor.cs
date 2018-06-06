
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 velocity=Vector3.zero;
    private Vector3 Rotation=Vector3.zero;
    private Vector3 camRotation = Vector3.zero;
    [SerializeField]
    private Camera cam;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    public void Move(Vector3 target)
    {
        velocity = target;
    }
    public void Rotate(Vector3 _rotate)
    {
        Rotation = _rotate;
    }
    public void camRotate(Vector3 _rotatecam)
    {
        camRotation = _rotatecam;
    }
    private void PerformMove()
    {
        if (velocity != Vector3.zero)
            rb.MovePosition(rb.position+velocity*Time.fixedDeltaTime);
    }
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Rotation));
        if (cam != null)
            cam.transform.Rotate(camRotation);
    }
    // Update is called once per frame
    void FixedUpdate () {
         PerformMove();
         PerformRotation();
	}
}
