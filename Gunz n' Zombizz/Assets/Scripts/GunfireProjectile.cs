using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunfireProjectile : MonoBehaviour
{

    public GameObject bulletprefab;
    public GameObject gunTip;

    public Text ammoUI;
    private int ammo = 10;

    // Start is called before the first frame update
    void Start()
    {
        ammoUI.text = "x " + ammo;
        ammoUI.color = Color.green;
        SoundManager.PlaySound("reload");
    }

    void BulletTravel()
    {
        
        if (ammo < 1)
        {
            Debug.Log("Out of Ammo");
            //ammoUI.text = "PRESS 'R' TO RELOAD";
            ammoUI.color = Color.red;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.PlaySound("gunshot");
                GameObject bulletObject = Instantiate(bulletprefab);
                bulletObject.transform.position = gunTip.transform.position + gunTip.transform.forward;
                bulletObject.transform.forward = gunTip.transform.forward;
                ammo--;
                ammoUI.text = "x " + ammo;
             }
        }
    }

    void GunReload()
    {
        if ((Input.GetKey(KeyCode.R)) && (ammo == 0)) // checks if gun is out of ammo
        {
            SoundManager.PlaySound("reload");
            ammo = 10;
            Debug.Log("Gun reloaded!");
            ammoUI.color = Color.green;
            ammoUI.text = "x " + ammo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BulletTravel();
        GunReload();
    }
}
