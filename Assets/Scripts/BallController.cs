    using UnityEngine;
    using UnityEngine.Events;

    public class BallController : MonoBehaviour
    {
        private bool isBallLaunched;
        [SerializeField] private float force = 1f;
        [SerializeField] private InputManager inputManager;
        private Rigidbody ballRB;

        void Start(){
            if(isBallLaunched) return;
            isBallLaunched = true;
            ballRB = GetComponent<Rigidbody>();
            inputManager.OnSpacePressed.AddListener(LaunchBall);
        }

        private void LaunchBall(){
            ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
