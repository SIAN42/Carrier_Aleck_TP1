using UnityEngine;

public class CodeAVoir : MonoBehaviour{

// WheelCollider des 4 roues
    [SerializeField] private WheelCollider roueFL;
    [SerializeField] private WheelCollider roueFR;
    [SerializeField] private WheelCollider roueRL;
    [SerializeField] private WheelCollider roueRR;

    // variables de mouvement
    [SerializeField] private float acceleration = 500f;
    [SerializeField] private float breakingForce = 300f;
    [SerializeField] private float maxTurnAngle = 15f;

    // variables de mouvement en cours
    private float currentAcceleration = 0;
    private float currentBreakForce = 0;
    private float currentTurnAngle = 0;

// https://www.youtube.com/watch?v=QQs9MWLU_tU&t=2s
// https://docs.unity3d.com/Manual/WheelColliderTutorial.html
// https://prasetion.medium.com/basic-car-movement-with-new-input-system-unity-f604229da834

    void Start()
    {
        
    }

    void Update()
    {

        // Force des roues avant
        roueFL.motorTorque = currentAcceleration;
        roueFR.motorTorque = currentAcceleration;

        // Force de freinement des 4 roues
        roueFL.brakeTorque = currentBreakForce;
        roueFR.brakeTorque = currentBreakForce;
        roueRL.brakeTorque = currentBreakForce;
        roueRR.brakeTorque = currentBreakForce;

        // Angle du virage
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontale");
        roueFL.steerAngle = currentTurnAngle;
        roueFR.steerAngle = currentTurnAngle;
    }

}
