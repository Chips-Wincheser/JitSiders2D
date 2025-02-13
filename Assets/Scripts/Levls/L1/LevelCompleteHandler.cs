using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteHandler : MonoBehaviour
{
    [SerializeField] private Inventory _inventoryPlayer;
    [SerializeField] private ImageCoin[] _coinsImages;
    [SerializeField] private Canvas _FinishCanvas;

    private List<Coin> _coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Inventory>(out Inventory _))
        {
            _FinishCanvas.gameObject.SetActive(true);

            if (_inventoryPlayer.ShowCoinsList().Count>0)
            {
                for (int i = 0; i < _inventoryPlayer.ShowCoinsList().Count; i++)
                {
                    _coinsImages[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
