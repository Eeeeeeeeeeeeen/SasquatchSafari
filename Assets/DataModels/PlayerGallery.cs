using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataModels
{
    [Serializable]
    public class PlayerGallery
    {
        public string PlayerName;

        public List<PictureModel> Pictures;

        public PlayerGallery(string playerName)
        {
            PlayerName = playerName;
            Pictures = new List<PictureModel>();
        }
    }
}
