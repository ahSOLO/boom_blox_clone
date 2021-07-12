using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float ballVelocity;
    [SerializeField] float coolDown; // Cooldown to prevent firing balls too quickly
    [SerializeField] float lastFired;
    bool mouseDown;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 
            && lastFired < Time.timeSinceLevelLoad - coolDown
            && GameManager.instance.ballsRemaining > 0
            && mouseDown == false)
        {
            var obj = Instantiate(ball, Camera.main.transform.position, Quaternion.identity, transform);
            var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
            obj.GetComponent<Rigidbody>().velocity = (target - Camera.main.transform.position).normalized * ballVelocity;
            
            GameManager.instance.UpdateBR(GameManager.instance.ballsRemaining - 1);
            
            lastFired = Time.timeSinceLevelLoad;
            mouseDown = true;
        }
        else
        {
            mouseDown = false;
        }
    }
}
