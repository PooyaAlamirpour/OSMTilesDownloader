using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMTilesDownloader.Presenter
{
    interface IProgressBar
    {
        void UpdateProgressBar(int level);
    }
}
