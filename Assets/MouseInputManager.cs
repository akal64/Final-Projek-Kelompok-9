using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    [SerializeField] SelectableObject SelectableObject;
    private void Update()
    {
        // Cek jika tombol kiri mouse ditekan
        if (Input.GetMouseButtonUp(0))
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
                    // Lakukan seleksi objek
                    selectableObject.OnMouseDown();
                }
            }
        }
    }

}
