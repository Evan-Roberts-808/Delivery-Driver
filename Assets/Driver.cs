using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Variables
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    IEnumerator ResetSpeedAfterDelay(float originalSpeed)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("back to original Speed");
        moveSpeed = originalSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        float originalSpeed = moveSpeed;
        Debug.Log("Slow down");
        moveSpeed = slowSpeed;
        
        StartCoroutine(ResetSpeedAfterDelay(originalSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("Speed Boost");
            float originalSpeed = moveSpeed;
            moveSpeed = boostSpeed;

            StartCoroutine(ResetSpeedAfterDelay(originalSpeed));
        }

    }
}
