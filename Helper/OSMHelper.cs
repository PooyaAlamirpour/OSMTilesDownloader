using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMTilesDownloader.Helper
{
    public class OSMHelper
    {
        private string[] _BoundaryName = { "left", "bottom", "right", "top" };

        internal Models.BoundaryModel ParseOsmosis(string Boundary)
        {
            String[] splitedBoundary = Boundary.Split(' ');
            if(splitedBoundary.Length == 4)
            {
                Models.BoundaryModel _model = new Models.BoundaryModel();
                for (int i = 0; i < 4; i++)
                {
                    // Finding value of left, bottom, right and top.
                    if(splitedBoundary[i].ToLower().Contains(_BoundaryName[i]))
                    {
                        // Extract value from the input string.
                        string tmp = splitedBoundary[i].Replace(_BoundaryName[i] + "=", "");
                        double value = Convert.ToDouble(tmp);
                        _model.GetType().GetProperty(_BoundaryName[i]).SetValue(_model, value);
                    }
                    else
                    {
                        // Something is missing in ordering of boundary value.
                        return null;
                    }
                }
                return _model;
            }
            else
            {
                // Something is missing in number of the splited string. It have to be forth.
                return null;
            }
        }
    }
}
