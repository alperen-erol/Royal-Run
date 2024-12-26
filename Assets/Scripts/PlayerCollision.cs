using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;

    const string hitString = "Hit";

    float cooldownTimer = 0f;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(-2f);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}
