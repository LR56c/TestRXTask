using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MyPresenter : MonoBehaviour
{
   private ReactiveCommand myCommand;

   public Button resButton;
   private MyPlayer player;
   private void Start()
   {
      player = new MyPlayer();
      player.Res.BindTo(resButton);
      player.Res.Subscribe(_ => Debug.Log("a"));
   }

   private void Update()
   {
      if (Keyboard.current.aKey.wasPressedThisFrame)
      {
         player.Hp.Value = 0;
      }
   }
}


public class MyPlayer
{
   public ReactiveProperty<int> Hp;
   public ReactiveCommand Res;

   public MyPlayer()
   {
      Hp = new ReactiveProperty<int>(100);

      Res = Hp.Select(x => x <= 0).ToReactiveCommand();

      Res.Subscribe(_ => Hp.Value = 1000);
   }
}