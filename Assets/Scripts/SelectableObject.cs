using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    // Simpan referensi ke komponen SpriteRenderer
    private SpriteRenderer spriteRenderer;
    Vector2 targetposition;

    // Menyimpan status seleksi objek
    private bool isSelected = false;

    private void Start()
    {
        // Dapatkan referensi ke komponen SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Cek jika objek sedang diseleksi
        if (isSelected == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Perbarui posisi objek mengikuti posisi pointer mouse
                targetposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }
            if (new Vector2(transform.position.x, transform.position.y) != targetposition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetposition, 5f * Time.deltaTime);

            }

        }
    }

    public void OnMouseDown()
    {
        // Ubah status seleksi objek
        isSelected = true;

        // Ganti warna sprite saat objek di-klik
        spriteRenderer.color = Color.white;
    }

    public void DeselectObject()
    {
        // Ubah status seleksi objek
        isSelected = false;

        // Ganti warna sprite saat objek tidak diseleksi
        spriteRenderer.color = Color.gray;
    }

}
