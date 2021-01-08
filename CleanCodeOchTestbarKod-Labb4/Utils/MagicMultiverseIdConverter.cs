using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4
{
    public class MagicMultiverseIdConverter
    {
        public string ConvertMultiverseIdToImageLink(int multiverseId)
        {
            return $"https://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={multiverseId}&type=card";
        }
    }
}
