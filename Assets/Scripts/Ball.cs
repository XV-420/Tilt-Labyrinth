using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private UIEventChannelSO uiEventChannel;
    [Header("Position for where the ball is reset to when reset is called")]
    [SerializeField] private Transform spawnPos;

    [Header("Lowest the ball can go")]
    [SerializeField] private Transform lowBounds;

    private TiltControls tiltControls;
    
    private void Start()
    {
        tiltControls = GetComponent<TiltControls>();
    }

    public Transform GetLowBounds()
    {
        return lowBounds;
    }

    //function to reset the ball to certain pos
    public void ResetBall()
    {
        transform.position = spawnPos.position;
        tiltControls.ZeroVelocity();
    }

    //checks and resets the ball
    public void FixedUpdate()
    {
        if(transform.position.y < lowBounds.position.y)
            ResetBall();
    }

    //waits a second before resetting the ball
    private IEnumerator WaitBeforeRest(GameObject other)
    {
        // suspend execution for 1 second
        yield return new WaitForSeconds(1);
        if (other.gameObject.transform.position.y > transform.position.y)
            ResetBall();
    }
    
    

    private void OnEnable()
    {
        uiEventChannel.OnReset += ResetBall;
    }
    private void OnDisable()
    {
        uiEventChannel.OnReset -= ResetBall;
    }

    
}
