using UnityEngine.InputSystem;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // variables
    [SerializeField] float steerSpeed = 180f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 7.5f;
    [SerializeField] float boostSpeed = 15f;
    [SerializeField] bool speedEffectActive = false;
    [SerializeField] float speedEffectTime = 0f;
    void Update()
    {
        // movement logic
        float steerTick = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveTick = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerTick);
        transform.Translate(0, moveTick, 0);
        if (speedEffectActive)
        {
            if (speedEffectTime < 5)
            {
                speedEffectTime += Time.deltaTime;
            }
            else
            {
                moveSpeed = 10f;
                speedEffectActive = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // collision detector for boosts and bumps
        if (other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
            speedEffectTime = 0f;
            speedEffectActive = true;
        }
        else if (other.tag == "Bump")
        {
            moveSpeed = slowSpeed;
            speedEffectTime = 0f;
            speedEffectActive = true;
        }
    }
}
