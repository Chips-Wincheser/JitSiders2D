using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteHandler : MonoBehaviour
{
    [SerializeField] private Inventory _inventoryPlayer;
    [SerializeField] private ImageCoin[] _coinsImages;
    [SerializeField] private Canvas _FinishCanvas;
    [SerializeField] private TeleportNextLevl _teleport;

    private List<Coin> _coins;

    private void OnEnable()
    {
        _teleport.FinishedLevl+=Finish;
    }

    private void OnDisable()
    {
        _teleport.FinishedLevl-=Finish;
    }

    private void Finish(Collider2D collision)
    {
        _FinishCanvas.gameObject.SetActive(true);

        int coinsCount = _inventoryPlayer.ShowCoinsList().Count;
        int imagesCount = _coinsImages.Length;

        for (int i = 0; i < coinsCount; i++)
        {
            if (i < imagesCount)
            {
                _coinsImages[i].gameObject.SetActive(true);
            }
        }
    }
}
