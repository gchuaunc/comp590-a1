using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Pew pewPrefab;

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
        pew.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * Random.Range(500f, 750f));
    }
}
