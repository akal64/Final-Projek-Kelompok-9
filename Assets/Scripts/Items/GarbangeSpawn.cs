using UnityEngine;
using UnityEngine.Tilemaps;

public class GarbangeSpawn : MonoBehaviour
{
     public Tilemap[] tilemaps; // Array dari Tilemap yang akan di-spawn

    private void Start()
    {
        SpawnRandomTilemap();
    }

    private void SpawnRandomTilemap()
    {
        int randomIndex = Random.Range(0, tilemaps.Length); // Mendapatkan indeks acak dari array Tilemap
        Tilemap tilemapToSpawn = tilemaps[randomIndex]; // Mengambil Tilemap sesuai indeks acak

        Instantiate(tilemapToSpawn, transform.position, Quaternion.identity); // Membuat instance dari Tilemap pada posisi spawner
    }
}
