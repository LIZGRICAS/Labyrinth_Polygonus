using UnityEngine;
using UnityEngine.UI; // Necesario para acceder al Text UI

public class Schedule : MonoBehaviour
{
    public Text textoCronometro; // Para asignar el Text de UI en el Inspector
    private float tiempoRestante = 30f; // 30 segundos (o ajusta el tiempo que necesites)
    private bool cronometroActivo = false;

    void Start()
    {
        // El cronómetro comienza después de 3 segundos
        Invoke("IniciarCronometro", 3f); // Llama a IniciarCronometro después de 3 segundos
    }

    void Update()
    {
        if (cronometroActivo)
        {
            // Disminuir el tiempo restante
            tiempoRestante -= Time.deltaTime;

            // Si el tiempo llega a cero, detener el cronómetro
            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                cronometroActivo = false; // Detener el cronómetro
            }

            // Actualizar el texto del cronómetro
            ActualizarTexto();
        }
    }

    void IniciarCronometro()
    {
        cronometroActivo = true; // Iniciar el cronómetro
    }

    void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60); // Calcular minutos
        int segundos = Mathf.FloorToInt(tiempoRestante % 60); // Calcular segundos

        // Mostrar el cronómetro en formato "mm:ss"
        textoCronometro.text = string.Format("Time: {0:00}:{1:00}", minutos, segundos);
    }
}
