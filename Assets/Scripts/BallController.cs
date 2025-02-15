    using UnityEngine;
    using UnityEngine.Events;

    public class BallController : MonoBehaviour
    {
        
        [SerializeField] private float force = 1f;
        [SerializeField] private Transform ballAnchor;
        [SerializeField] private Transform launchIndicator;
        private bool isBallLaunched;
      
        [SerializeField] private InputManager inputManager;
        private Rigidbody ballRB;

        void Start(){
            ballRB = GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;
            inputManager.OnSpacePressed.AddListener(LaunchBall);
            transform.parent = ballAnchor;
            transform.localPosition = Vector3.zero;     
            ballRB.isKinematic = true;
            ResetBall();       
        }

        private void LaunchBall(){
            if(isBallLaunched) return;
            isBallLaunched = true;
            transform.parent = null;
            ballRB.isKinematic = false;
            ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
            launchIndicator.gameObject.SetActive(false);
        }

        public void ResetBall(){
            isBallLaunched = false;
            ballRB.isKinematic = true;
            launchIndicator.gameObject.SetActive(true);
            transform.parent = ballAnchor;
            transform.localPosition = Vector3.zero;
        }


    }
