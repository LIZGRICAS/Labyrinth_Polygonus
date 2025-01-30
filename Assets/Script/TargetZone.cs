using UnityEngine;

public class TargetZone : MonoBehaviour
{
    public ControllerSignsChronometer controladorLetreros;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            controladorLetreros.MostrarYouWin(); // Llamamos al método para mostrar "You Win"
        }
    }
}
