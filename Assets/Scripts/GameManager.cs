using UnityEngine;
using TMPro;
using System.Collections;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private BallController ball;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    



    private void Start(){
         inputManager.OnResetPressed.AddListener(HandleReset);
         SetPins();

    }    

    private void HandleReset(){
        ball.ResetBall();
        SetPins();
    }

    private void SetPins(){
      if(pinObjects){
        foreach(Transform child in pinObjects.transform){
            Destroy(child.gameObject);
        }
        Destroy(pinObjects);
      }

      pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, 
                   Quaternion.identity, transform);

      fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
      StartCoroutine(RegisterFallTriggers());
     
    }

    private IEnumerator RegisterFallTriggers(){
        yield return new WaitForSeconds(0.1f);
        foreach(FallTrigger fallTrigger in fallTriggers){
            fallTrigger.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore(){
        score++;
        scoreText.text = $"Score: {score}";
    }




}
