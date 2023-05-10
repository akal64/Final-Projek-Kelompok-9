using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float moveSpeed = 5f; // kecepatan gerakan
    private Vector3 targetPosition; // posisi target untuk gerakan
    private bool facingRight = true; // menghadap ke kanan

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ketika tombol kiri mouse ditekan
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // konversi posisi mouse ke posisi di dunia game
            targetPosition.z = transform.position.z; // tetap pada ketinggian yang sama

            // mengatur arah menghadap objek
            if (targetPosition.x < transform.position.x) // jika target berada di sebelah kiri objek
            {
                facingRight = false; // flip x dimatikan
            }
            else if (targetPosition.x > transform.position.x) // jika target berada di sebelah kanan objek
            {
                facingRight = true; // flip x dinyalakan
            }
        }

        if (transform.position != targetPosition) // jika posisi drone belum mencapai target
        {
            // mengatur arah menghadap objek
            if (targetPosition.x < transform.position.x) // jika target berada di sebelah kiri objek
            {
                facingRight = false; // flip x dimatikan
            }
            else if (targetPosition.x > transform.position.x) // jika target berada di sebelah kanan objek
            {
                facingRight = true; // flip x dinyalakan
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // gerak ke posisi target

            // mengatur rotasi z pada objek
            float rotationZ = 0f;
            if (facingRight == true)
            {
                if (targetPosition.y > transform.position.y) // jika target berada di atas objek
                {
                    rotationZ = 45f; // rotasi z > 0
                }
                else if (targetPosition.y < transform.position.y) // jika target berada di bawah objek
                {
                    rotationZ = -45f; // rotasi z < 0
                }
            }
            else if (facingRight == false)
            {
                if (targetPosition.y > transform.position.y) // jika target berada di atas objek
                {
                    rotationZ = -45f; // rotasi z > 0
                }
                else if (targetPosition.y < transform.position.y) // jika target berada di bawah objek
                {
                    rotationZ = 45f; // rotasi z < 0
                }
            }
            if (Mathf.Abs(targetPosition.y - transform.position.y) <= 1f)
            {
                rotationZ = 0f;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ); // ubah rotasi z pada objek
        }

        // mengatur flip x pada objek
        if (facingRight && transform.localScale.x < 0 || !facingRight && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

}
