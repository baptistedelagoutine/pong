using UnityEngine;

public class UserControl : MonoBehaviour
{
    public KeyCode KeyUp;
    public KeyCode KeyDown;
    public float Vitesse;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyUp) && transform.position.y < 4.45f)
            transform.Translate(0, Vitesse, 0);
        if (Input.GetKey(KeyDown) && transform.position.y > -4.45f)
            transform.Translate(0, -Vitesse, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        audio.Play();
    }
}
