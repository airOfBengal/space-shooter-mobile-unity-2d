using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserBullet;
    public Transform basicShootPoint;
    public float shootingInterval;
    private float intervalReset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if(shootingInterval <= 0){
            shootingInterval = intervalReset;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
    }
}
