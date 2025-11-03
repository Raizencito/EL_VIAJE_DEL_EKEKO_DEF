using UnityEngine;
using System.Collections.Generic;

public class PuzzleStonesManager : MonoBehaviour
{
    [Tooltip("Orden correcto de IDs (por ejemplo: Piedra1, Piedra2, ...)")]
    public string[] correctOrder;

    [Header("References")]
    public GameObject wiresLayer;       // parent con tiles de wires
    public GameObject wiresCollision;   // parent con colisiones de wires (tilemap collider)
    public GameObject treeObject;       // objeto que habilitarás al resolver

    private int currentIndex = 0;
    private bool solved = false;

    // Map ID -> StoneTrigger (para reiniciar/visualizar)
    private Dictionary<string, StoneTrigger> stones = new Dictionary<string, StoneTrigger>();

    public void RegisterStone(string id, StoneTrigger st)
    {
        if (!stones.ContainsKey(id))
            stones.Add(id, st);
    }

    public void StoneActivated(string id)
    {
        if (solved) return;

        // si el id es el que esperamos
        if (currentIndex < correctOrder.Length && id == correctOrder[currentIndex])
        {
            Debug.Log($"Correcto: {id}");
            currentIndex++;

            // marcar visualmente como activada
            if (stones.TryGetValue(id, out var s)) s.SetActiveVisual(true);

            if (currentIndex >= correctOrder.Length)
            {
                OnPuzzleSolved();
            }
        }
        else
        {
            Debug.Log($"Error con {id} — reiniciando puzzle");
            // efecto de error: reset visual y contador
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        currentIndex = 0;
        foreach (var kv in stones) kv.Value.SetActiveVisual(false);
        // aquí podés reproducir sonido de error
    }

    private void OnPuzzleSolved()
    {
        solved = true;
        Debug.Log("Puzzle resuelto!");
        if (wiresLayer != null) wiresLayer.SetActive(false);
        if (wiresCollision != null) wiresCollision.SetActive(false);
        if (treeObject != null) treeObject.SetActive(true);

        // Opcional: deshabilitar triggers
        foreach (var kv in stones) kv.Value.enabled = false;
    }
}
