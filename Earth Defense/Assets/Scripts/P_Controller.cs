using UnityEngine;

[RequireComponent(typeof(P_Motor))]
public class P_Controller : MonoBehaviour {

    [SerializeField]
    private float lookSensetivity = 3f;

    private P_Motor motor;

    public AudioSource musicSource;
    public AudioClip musicClip;

    void Start()
    {
        motor = GetComponent<P_Motor>();

        musicSource.clip = musicClip;
        musicSource.Play();

        Cursor.visible = false;
    }

    void Update()
    {
        //Calculate rotation as a 3d vector... TURNING AROUND
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensetivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //calculate camera rotation
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensetivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);   

    }

}
