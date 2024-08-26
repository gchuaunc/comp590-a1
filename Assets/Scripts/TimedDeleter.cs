using UnityEngine;

public class TimedDeleter : MonoBehaviour
{
    [SerializeField] private float deleteTimeSec;

    private float timeElapsed;

    void OnEnable()
    {
        timeElapsed = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > deleteTimeSec) {
            Destroy(gameObject);
        }
    }
}
