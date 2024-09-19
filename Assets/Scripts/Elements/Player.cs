using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform shootPosition;
    public GameDirector gameDirector;

    public Camera cam;

    public float attackRate;

    public Bullet bulletPrefab;

    public void Init()
    {
        StartShooting();
    }

    private void Update()
    {
        var mousePos = Input.mousePosition;
        var playerPositionOnScreen = cam.WorldToScreenPoint(transform.position);
        var direction = mousePos - playerPositionOnScreen;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      
    }

    private void StartShooting()
    {
        StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        gameDirector.audioManager.PlayShotAS();
        var newBullet = Instantiate(bulletPrefab);
        bulletPrefab.transform.position = shootPosition.position;
        newBullet.transform.rotation = shootPosition.rotation;
        newBullet.Init(shootPosition.right);
    }
}
