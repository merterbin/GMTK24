using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 3.0f;
    private bool isClimbing = false;
    private bool isTop = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isClimbing)
        {
            
            float vertical = Input.GetAxis("Vertical");
            
            Vector3 move = new Vector3(0, vertical * climbSpeed, 0);

            // Merdiven ��kma hareketini fizik tabanl� olarak uygula
            rb.velocity = new Vector3(rb.velocity.x, move.y, rb.velocity.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false; // Merdiven ��karken yer�ekimini kapat
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.useGravity = true; // Merdivenden ayr�ld���nda yer�ekimini a�
        }
    }
}
