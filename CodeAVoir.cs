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




     private VoitureMouvement controls;

// WheelCollider des 4 roues
    [SerializeField] private WheelCollider roueFL;
    [SerializeField] private WheelCollider roueFR;
    [SerializeField] private WheelCollider roueRL;
    [SerializeField] private WheelCollider roueRR;

    [SerializeField] private float motorTorque = 2000;
    [SerializeField] private float brakeTorque = 2000;
    [SerializeField] private float maxSpeed = 20;
    [SerializeField] private float steeringRange = 30;
    [SerializeField] private float steeringRangeAtMaxSpeed = 10;
    [SerializeField] private float centreOfGravityOffset = -1f;
    [SerializeField] private Rigidbody rigidBody;
    RoueController[] wheels;

    [SerializeField] float acceleration = 500f;
    [SerializeField] float breakingForce = 300f;

    float currentAcceleration = 0;
    float currentBreakForce = 0;

    void Awake(){

        controls = new VoitureMouvement();

    }

    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody>();

        // Adjust center of mass vertically, to help prevent the car from rolling
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;

        // Find all child GameObjects that have the WheelControl script attached
        wheels = GetComponentsInChildren<RoueController>();
    }

    // Update is called once per frame
    void Update()
    {

        currentAcceleration = acceleration * controls.Player.Move.ReadValue<Vector2>().y;

        // Calculate current speed in relation to the forward direction of the car
        // (this returns a negative number when traveling backwards)
        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);


        // Calculate how close the car is to top speed
        // as a number from zero to one
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);

        // Use that to calculate how much torque is available 
        // (zero torque at top speed)
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);

        // …and to calculate how much to steer 
        // (the car steers more gently at top speed)
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);

        // Check whether the user input is in the same direction 
        // as the car's velocity
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        foreach (var wheel in wheels)
        {
            // Apply steering to Wheel colliders that have "Steerable" enabled
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
            }
            
            if (isAccelerating)
            {
                // Apply torque to Wheel colliders that have "Motorized" enabled
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                }
                wheel.WheelCollider.brakeTorque = 0;
            }
            else
            {
                // If the user is trying to go in the opposite direction
                // apply brakes to all wheels
                wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                wheel.WheelCollider.motorTorque = 0;
            }

        }

    }



}
