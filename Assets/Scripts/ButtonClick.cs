using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Pew pewPrefab;
    [SerializeField] private float maxPewSpeed = 1000f;
    [SerializeField] private float minPewSpeed = 750f;
    [SerializeField] private float pewBloom = 200f;

    // Start is called before the first frame update
    void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Source: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.10/api/UnityEngine.InputSystem.EnhancedTouch.Touch.html
        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches) {
            if (touch.began) {
                SpawnPew();
            }
        }
        /*if (Touchscreen.current.press.IsPressed) {
            SpawnPew();
        }*/
    }

    private void SpawnPew() {
        Pew pew = Instantiate(pewPrefab);
        pew.transform.localPosition = transform.position;
        Rigidbody pewRb = pew.GetComponent<Rigidbody>();
        pewRb.AddForce(Camera.main.transform.forward * Random.Range(minPewSpeed, maxPewSpeed));
        pewRb.AddForce(Camera.main.transform.right * Random.Range(-pewBloom, pewBloom));
    }
}
