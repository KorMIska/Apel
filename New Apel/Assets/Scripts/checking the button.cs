using UnityEngine;

public class ChouseButton : MonoBehaviour
{
    [SerializeField] string Text;
    [SerializeField] GameObject PrefabPlayer;
    [SerializeField] GameObject canvas;
    [SerializeField] PlayerManager player;
    [SerializeField] GameObject cameraHolder;

    public void SetPlayer()
    {
        print("Buttom " + Text);
        if (player != null) 
        {
            print($"Персонаж на кнопке:{PrefabPlayer != null}");
            player.SetCharacter(PrefabPlayer);
            canvas.SetActive(false);
            cameraHolder.SetActive(false);

        }
    }
}
