using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Target : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnCollisionEnter(Collision collision) {
        Pew pew = collision.collider.GetComponent<Pew>();
        if (!pew) return;
        // got hit by a Pew
        animator.SetTrigger("Hit");
        Destroy(pew.gameObject);
        ScoreBoard.instance.IncreaseScore(100);
    }
}
