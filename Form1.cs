using OSMTilesDownloader.Core;
using OSMTilesDownloader.Helper;
using OSMTilesDownloader.Models;
using OSMTilesDownloader.Presenter;
using System;
using System.Collections;
using System.Collections.Async;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSMTilesDownloader
{
    public partial class Form1 : Form, IProgressBar, ILog
    {
        private Utilities Utility;
        private OSMHelper osm;
        private OSMTilesDownloader.Helper.Console log;

        public Form1()
        {
            InitializeComponent();
            Utility = new Utilities();
            osm = new OSMHelper();
            log = new OSMTilesDownloader.Helper.Console(this);
        }

        private void btnOpenOSM_Click(object sender, EventArgs e)
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            String Boundary = txtBoundary.Text;
            if(!string.IsNullOrEmpty(Boundary) && !string.IsNullOrWhiteSpace(Boundary))
            {
                // Parsing the boundary from string to boundary model.
                BoundaryModel bModel = osm.ParseOsmosis(Boundary);
                if(bModel != null)
                {
                    Tile leftBottom = Tile.CreateAroundLocation(bModel.left, bModel.bottom, Config.ZOOM);
                    Tile topRight = Tile.CreateAroundLocation(bModel.top, bModel.right, Config.ZOOM);

                    var minX = Math.Min(leftBottom.X, topRight.X);
                    var maxX = Math.Max(leftBottom.X, topRight.X);
                    var minY = Math.Min(leftBottom.Y, topRight.Y);
                    var maxY = Math.Max(leftBottom.Y, topRight.Y);

                    // Defining tile area.
                    TileRange range = new TileRange(minX, minY, maxX, maxY, Config.ZOOM);
                    AsyncDownloader asyncDownloader = new AsyncDownloader(this);
                    asyncDownloader.Download(range);
                }
                else
                {

                }
                
            }
            
        }

        public void UpdateProgressBar(int level)
        {
            pbDownload.Value = level;
        }

        public void Log(string message)
        {
            log.WriteLine(">> " + message);
        }

        public string LogPanel
        {
            get
            {
                return txtConsole.Text;
            }
            set
            {
                if (txtConsole.InvokeRequired)
                {
                    txtConsole.BeginInvoke(new MethodInvoker(delegate()
                    {
                        if (txtConsole.Text.Length >= 5000)
                        {
                            txtConsole.Text = "";
                        }
                        txtConsole.Text += value + "\r\n";
                        txtConsole.SelectionStart = txtConsole.TextLength;
                        txtConsole.ScrollToCaret();
                        
                    }));
                }
            }
        }
    }
}
