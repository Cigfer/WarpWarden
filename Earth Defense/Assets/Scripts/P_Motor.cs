using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class P_Motor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    private Rigidbody rb;

    void Start()
    {
        //uses RequireComponent so is completely legit
        rb = GetComponent<Rigidbody>();
    }

    //Gets rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Gets rotational vector for the camera
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    // Run every physics iteration
    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            PerformRotation();
        }
    }

    //Perform rotation
    void PerformRotation()
    {
        //Euler = x, y, z rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        //if a camera is present
        if (cam != null)
        {
            //Set rotation and clamp it
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
}
