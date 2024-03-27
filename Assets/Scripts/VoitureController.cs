using UnityEngine;

public class VoitureController : MonoBehaviour
{
    private VoitureMouvement controls;
// WheelCollider des 4 roues
    [SerializeField] private WheelCollider roueFL;
    [SerializeField] private WheelCollider roueFR;
    [SerializeField] private WheelCollider roueRL;
    [SerializeField] private WheelCollider roueRR;

    // wheel mesh
    [SerializeField] private Transform frontRightWheelMesh;
    [SerializeField] private Transform frontLeftWheelMesh;
    [SerializeField] private Transform backRightWheelMesh;
    [SerializeField] private Transform backLeftWheelMesh;

    
    [SerializeField] private float acceleration = 500f;
    [SerializeField] private float breakingForce = 300f;
    [SerializeField] private float maxTurnAngle = 15f;

    float currentAcceleration = 0;
    float currentBreakForce = 0;
    float currentTurnAngle = 0;

    void Awake()
    {
        controls = new VoitureMouvement();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void FixedUpdate()
    {
        currentAcceleration = acceleration * controls.Voiture.Bouge.ReadValue<Vector2>().y;

        roueFL.motorTorque = currentAcceleration;
        roueFL.motorTorque = currentAcceleration;

        roueFR.brakeTorque = currentBreakForce;
        roueFL.brakeTorque = currentBreakForce;
        roueRR.brakeTorque = currentBreakForce;
        roueRL.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * controls.Voiture.Bouge.ReadValue<Vector2>().x;
        roueFL.steerAngle = currentTurnAngle;
        roueFR.steerAngle = currentTurnAngle;

        SetWheel(roueFR, frontRightWheelMesh);
        SetWheel(roueFL, frontLeftWheelMesh);
        SetWheel(roueRR, backRightWheelMesh);
        SetWheel(roueRL, backLeftWheelMesh);

    }

    void SetWheel(WheelCollider wheelCol, Transform wheelMesh)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCol.GetWorldPose(out pos, out rot);

        wheelMesh.position = pos;
        wheelMesh.rotation = rot;

    }

}
