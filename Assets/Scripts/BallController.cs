    using UnityEngine;
    using UnityEngine.Events;

    public class BallController : MonoBehaviour
    {
        [SerializeField] private float force =1f;
        [SerializeField] private Transform ballAnchor;
        [SerializeField] private Transform launchIndicator;
        private bool isBallLaunched;
      
        private InputManager inputManager;
        private Rigidbody ballRB;

        void Start(){
            ballRB = GetComponent<Rigidbody>();
            if (inputManager == null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        // Check if inputManager was found before using it
        if (inputManager != null)
        {
            inputManager.OnSpacePressed.AddListener(LaunchBall);
        }
        else
        {
            Debug.LogError("InputManager not found! Make sure it's in the scene.");
        }
            transform.parent = ballAnchor;
            transform.localPosition = Vector3.zero;     
            ballRB.isKinematic = true;       
        }

        private void LaunchBall(){
            if(isBallLaunched) return;
            isBallLaunched = true;
            transform.parent = null;
            ballRB.isKinematic = false;
            ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
            launchIndicator.gameObject.SetActive(false);
        }
    }
