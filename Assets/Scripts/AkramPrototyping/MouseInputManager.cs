using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    // Menyimpan referensi ke objek yang sedang diseleksi
    [SerializeField] SelectableObject selectedObject;

    private void Update()
    {
        // Cek jika tombol kiri mouse ditekan
        if (Input.GetMouseButtonDown(0))
        {
            // Konversi posisi mouse dari layar menjadi posisi dalam dunia game
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Raycast dari posisi mouse untuk mencari objek yang di-klik
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Cek jika terdapat objek yang di-klik
            if (hit.collider != null)
            {
                // Ambil referensi ke komponen SelectableObject pada objek yang di-klik
                SelectableObject selectableObject = hit.collider.GetComponent<SelectableObject>();

                // Cek jika objek memiliki komponen SelectableObject
                if (selectableObject != null)
                {
                    // Cek jika objek belum diseleksi sebelumnya
                    if (selectedObject == null)
                    {
                        // Lakukan seleksi objek
                        selectedObject = selectableObject;
                        selectedObject.OnMouseDown();
                    }
                }
            }
        }

        // Cek jika tombol kiri mouse dilepas
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cek jika ada objek yang sedang diseleksi
            if (selectedObject != null)
            {
                // Hentikan seleksi objek
                selectedObject.DeselectObject();
                selectedObject = null;
            }
        }
    }
}
