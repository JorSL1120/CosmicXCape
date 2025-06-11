using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private string currentState = "Idle";
    private bool running = false;
    private bool walking = false;

    Inventory inv;
    private CharacterController CC;
    private VidaPlayer VidaPlayerScript;
    public float Speed;
    public float Sprint;
    public float SpeedRotation;
    public GameObject RayoSprite;
    public GameObject ParticlesRayo;
    public GameObject EscudoText;
    public GameObject ParticlesEscudo;
    public GameObject ParticlesMuestras;

    [HideInInspector] public float bebidaTime; //Tiempo de boost

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        inv = GetComponent<Inventory>();
        CC = GetComponent<CharacterController>();
        VidaPlayerScript = GetComponent<VidaPlayer>();
        RayoSprite.SetActive(false);
        ParticlesRayo.SetActive(false);
        EscudoText.SetActive(false);
        ParticlesEscudo.SetActive(false);
        ParticlesMuestras.SetActive(false);
    }

    void Update()
    {
        Movimiento_Personaje();
        BoostBebida();

        var state = GetState();
        if(state.Equals(currentState))
        {
            return;
        }
        currentState = state;
        anim.CrossFade(currentState, 0.2f, 0);
    }

    private void Movimiento_Personaje()
    {
        Vector3 movimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movimiento.Normalize();

        if (movimiento != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * SpeedRotation);
            walking = true;
        }
        else
        {
            walking = false;
        }

        if (Input.GetAxis("Run") > 0)
        {
            CC.Move(movimiento * (Speed * Sprint) * Time.deltaTime);
            walking = false;
            running = true;
            VidaPlayerScript.decremento = 5;
        }
        else
        {
            CC.Move(movimiento * Speed * Time.deltaTime);
            running = false;
            VidaPlayerScript.decremento = 1;
        }
    }

    private string GetState()
    {
        if (walking)
        {
            return "Walk";
        }
        else if (running)
        {
            return "Run";
        }
        return "Idle";
    }

    private void OnTriggerEnter(Collider other)
    {
        Piezas piezas = other.GetComponent<Piezas>();
        Escudo escudo = other.GetComponent<Escudo>();
        BebidaEnergetica bebida = other.GetComponent<BebidaEnergetica>();
        if (piezas != null)
        {
            inv.AddPiezas(piezas.Value);
            StartCoroutine(AppearAndDisappearParticlesMuestras());
            piezas.Hide();
        }
        if (escudo != null)
        {
            StartCoroutine(AppearAndDisappearEscudo());
            VidaPlayerScript.ShieldTime = escudo.ShieldTime;
            escudo.Hide();
        }
        if (bebida != null)
        {
            StartCoroutine(AppearAndDisappearRayo());
            bebidaTime = bebida.EnergeticaOn;
            bebida.Hide();
        }
    }

    void BoostBebida()
    {
        if (bebidaTime <= 0)
        {
            Sprint = 2f;
        }
        else
        {
            Sprint = 3f;
        }
        bebidaTime -= Time.deltaTime;
    }

    IEnumerator AppearAndDisappearRayo()
    {
        // Hacer que la imagen sea visible
        RayoSprite.SetActive(true);
        ParticlesRayo.SetActive(true);

        // Esperar 0.5 segundos
        yield return new WaitForSeconds(5f);

        // Hacer que la imagen sea invisible
        RayoSprite.SetActive(false);
        ParticlesRayo.SetActive(false);
    }

    IEnumerator AppearAndDisappearEscudo()
    {
        // Hacer que la imagen sea visible
        EscudoText.SetActive(true);
        ParticlesEscudo.SetActive(true);

        // Esperar 0.5 segundos
        yield return new WaitForSeconds(5f);

        // Hacer que la imagen sea invisible
        EscudoText.SetActive(false);
        ParticlesEscudo.SetActive(false);
    }

    IEnumerator AppearAndDisappearParticlesMuestras()
    {
        // Hacer que la imagen sea visible
        ParticlesMuestras.SetActive(true);

        // Esperar 0.5 segundos
        yield return new WaitForSeconds(3f);

        // Hacer que la imagen sea invisible
        ParticlesMuestras.SetActive(false);
    }
}
