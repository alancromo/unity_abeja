using UnityEngine;
using System.Collections;

public class Hornet : MonoBehaviour {
    public GameObject Camera;
    Animator hornet;
    private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
        hornet = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S))
        {
            hornet.SetBool("idle", true);
            hornet.SetBool("walk", false);
            hornet.SetBool("turnleft", false);
            hornet.SetBool("turnright", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            hornet.SetBool("walk", true);
            hornet.SetBool("idle", false);
            hornet.SetBool("turnleft", false);
            hornet.SetBool("turnright", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            hornet.SetBool("turnleft", true);
            hornet.SetBool("turnright", false);
            hornet.SetBool("walk", false);
            hornet.SetBool("idle", false);
            StartCoroutine("idle");
            idle();
        }
        if (Input.GetKey(KeyCode.D))
        {
            hornet.SetBool("turnright", true);
            hornet.SetBool("turnleft", false);
            hornet.SetBool("walk", false);
            hornet.SetBool("idle", false);
            StartCoroutine("idle");
            idle();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            hornet.SetBool("takeoff", true);
            hornet.SetBool("idle", false);
            StartCoroutine("fly");
            fly();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            hornet.SetBool("landing", true);
            hornet.SetBool("fly", false);
            hornet.SetBool("flyinplace", false);
            StartCoroutine("idle");
            idle();
        }
        if (Input.GetKey(KeyCode.F))
        {
            hornet.SetBool("flyinplace", true);
            hornet.SetBool("fly", false);
            StartCoroutine("attack");
            attack();
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            hornet.SetBool("flyinplace", true);
            hornet.SetBool("fly", false);
            StartCoroutine("die");
            die();
        }
        if (Input.GetKey(KeyCode.A))
        {
            hornet.SetBool("flyleft", true);
            hornet.SetBool("fly", false);
            hornet.SetBool("flyright", false);
            hornet.SetBool("flyinplace", false);
            StartCoroutine("fly");
            fly();
        }
        if (Input.GetKey(KeyCode.D))
        {
            hornet.SetBool("flyright", true);
            hornet.SetBool("flyinplace", false);
            hornet.SetBool("flyleft", false);
            hornet.SetBool("fly", false);
            StartCoroutine("fly");
            fly();
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            hornet.SetBool("flyinplace", true);
            hornet.SetBool("fly", false);
            StartCoroutine("hit");
            hit();
        }
        if (Input.GetKey(KeyCode.W))
        {
            hornet.SetBool("fly", true);
            hornet.SetBool("flyleft", false);
            hornet.SetBool("flyright", false);
            hornet.SetBool("flyinplace", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            hornet.SetBool("flyinplace", true);
            hornet.SetBool("fly",false);
            hornet.SetBool("flyleft", false);
            hornet.SetBool("flyright", false);
            hornet.SetBool("attack", false);
            hornet.SetBool("hit", false);
        }
	}
    IEnumerator idle()
    {
        yield return new WaitForSeconds(0.5f);
        hornet.SetBool("idle", true);
        hornet.SetBool("walk", false);
        hornet.SetBool("turnleft", false);
        hornet.SetBool("turnright", false);
        hornet.SetBool("landing", false);
    }
    IEnumerator fly()
    {
        yield return new WaitForSeconds(0.1f);
        hornet.SetBool("takeoff", false);
        hornet.SetBool("fly", true);
        hornet.SetBool("attack", false);
        hornet.SetBool("flyleft", false);
        hornet.SetBool("flyright", false);
        hornet.SetBool("hit", false);
    }
    IEnumerator flyinplace()
    {

        yield return new WaitForSeconds(0.2f);
        hornet.SetBool("flyinplace", true);
        hornet.SetBool("attack", false);
        hornet.SetBool("hit", false);
        yield return new WaitForSeconds(0.2f);
        Camera.GetComponent<CameraFollow>().enabled = true;
        Camera.GetComponent<CameraLookAt>().enabled = true;
        hornet.SetBool("fly", false);
        hornet.SetBool("flyleft", false);
        hornet.SetBool("flyright", false);
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.3f);
        Camera.GetComponent<CameraFollow>().enabled = false;
        Camera.GetComponent<CameraLookAt>().enabled = false;
        hornet.SetBool("attack",true);
        hornet.SetBool("flyinplace", false);
        StartCoroutine("flyinplace");
        flyinplace();
    }
    IEnumerator hit()
    {
        yield return new WaitForSeconds(0.3f);
        Camera.GetComponent<CameraFollow>().enabled = false;
        Camera.GetComponent<CameraLookAt>().enabled = false;
        hornet.SetBool("hit", true);
        hornet.SetBool("flyinplace", false);
        StartCoroutine("flyinplace");
        flyinplace();
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(0.3f);
        Camera.GetComponent<CameraFollow>().enabled = false;
        hornet.SetBool("die", true);
        hornet.SetBool("flyinplace", false);
    }
}
