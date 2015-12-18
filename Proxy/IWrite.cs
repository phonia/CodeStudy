using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    public interface IGamePlayer
    {
        void Play();
    }

    public class GamePlayer : IGamePlayer
    {
        public void Play()
        {
            Console.Write("Play");
        }
    }

    public class GamePlayerProxy : IGamePlayer
    {
        private IGamePlayer _gamePlayer=null;

        public GamePlayerProxy(IGamePlayer gamePlayer)
        {
            this._gamePlayer = gamePlayer;
        }

        public void Play()
        {
            if (_gamePlayer == null) throw new ArgumentNullException();
            this._gamePlayer.Play();
        }
    }

}
