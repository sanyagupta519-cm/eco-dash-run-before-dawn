using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;
    public AudioSource gunSound;
    public GameObject hitEffect; // Optional: assign particle in Inspector
    void Start(){
        gunSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            if(gunSound.isPlaying){
                gunSound.Stop();
            }
            if(gunSound != null && !gunSound.isPlaying){
                gunSound.Play();
            }
        }
    }

    void Shoot()
{
    RaycastHit hit;

    Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

    if (Physics.Raycast(ray, out hit, range))
    {
        Debug.Log("Hit: " + hit.collider.name);

        if (hit.collider.transform.root.CompareTag("Enemy"))
        {
            Destroy(hit.collider.transform.root.gameObject);
        }
    }
}
}