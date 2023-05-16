using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isSelected = false;

    private void Update()
    {
        // Cek jika objek dipilih
        if (isSelected == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                // Konversi posisi mouse dari layar menjadi posisi dalam dunia game
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Update posisi objek sesuai dengan posisi mouse
                transform.position = Vector2.MoveTowards(transform.position, mousePosition, 5f * Time.deltaTime);
                Debug.Log(transform.position);
            }
        }
    }

    public void OnMouseDown()
    {
        // Toggle status seleksi objek
        isSelected = true;

        // Ganti warna sprite saat objek di-klik dan diseleksi
        if (isSelected)
        {
            spriteRenderer.color = Color.red;
            Debug.Log("Objek terselek");
        }
        else
        {
            spriteRenderer.color = Color.white;
            Debug.Log("Obejk tidak terselek");
        }
    }

}
