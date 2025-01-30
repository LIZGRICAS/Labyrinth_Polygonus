using UnityEngine;
using UnityEngine.UI;

public class ControllerSignsChronometer : MonoBehaviour
{
    public Text letreroLetsGo;     // Letrero "Let's Go"
    public Text letreroYouWin;     // Letrero "You Win"
    public Text letreroGameOver;   // Letrero "Game Over"
    public float tiempoLimite = 60f; // Tiempo límite de 1 minuto

    private float tiempoRestante;
    private bool cronometroActivo = false;
    private bool jugadorGano = false;

    void Start()
    {
        // Inicializa los letreros
        letreroLetsGo.gameObject.SetActive(false);
        letreroYouWin.gameObject.SetActive(false);
        letreroGameOver.gameObject.SetActive(false);

        // Al principio, mostramos el letrero de "Let's Go" y comenzamos la espera
        letreroLetsGo.gameObject.SetActive(true);
        Invoke("OcultarLetsGo", 3f); // El letrero de "Let's Go" se oculta después de 3 segundos
    }

    // Método para ocultar el letrero "Let's Go" y comenzar el cronómetro
    void OcultarLetsGo()
    {
        letreroLetsGo.gameObject.SetActive(false); // Ocultamos el letrero
        IniciarCronometro(); // Iniciamos el cronómetro
    }

    // Iniciar el cronómetro
    void IniciarCronometro()
    {
        tiempoRestante = tiempoLimite;  // Establecemos el tiempo límite
        cronometroActivo = true;  // Activamos el cronómetro
    }

    void Update()
    {
        if (cronometroActivo)
        {
            // Disminuir el tiempo restante
            tiempoRestante -= Time.deltaTime;

            // Si el cronómetro llega a cero y el jugador no ha llegado a la meta, mostrar "Game Over"
            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                cronometroActivo = false;
                if (!jugadorGano)
                {
                    MostrarGameOver();
                }
            }

            // Mostrar el cronómetro en formato mm:ss
            ActualizarCronometro();
        }
    }

    // Mostrar el letrero "You Win"
    public void MostrarYouWin()
    {
        if (!jugadorGano)
        {
            letreroYouWin.gameObject.SetActive(true);
            jugadorGano = true;
        }
    }

    // Mostrar el letrero "Game Over"
    void MostrarGameOver()
    {
        letreroGameOver.gameObject.SetActive(true);
    }

    // Actualizar el texto del cronómetro en el formato "mm:ss"
    void ActualizarCronometro()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60); // Calcular minutos
        int segundos = Mathf.FloorToInt(tiempoRestante % 60); // Calcular segundos

        // Puedes mostrar el cronómetro en la UI si lo deseas
        Debug.Log(string.Format("{0:00}:{1:00}", minutos, segundos));
    }
}
