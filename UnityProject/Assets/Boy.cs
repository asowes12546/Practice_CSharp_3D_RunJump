using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;
    public Rigidbody rig;
    public Animator ator;
    public AudioSource audio;
    public AudioClip a;
    private bool isTouch;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (isTouch == true) 
        {
            rig.AddForce(Vector3.up * jump);
            ator.SetBool("跳躍開關", true);
            audio.PlayOneShot(a);
        }
        isTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ator.SetBool("跳躍開關", false);
        isTouch = true;
    }
}
