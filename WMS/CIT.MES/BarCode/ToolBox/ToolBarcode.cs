using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CIT.MES.BarCode;
using System.Windows.Forms;

namespace CIT.MES.ToolBox
{
    [ToolAttribute("条码","Resources.barcodeNew.png", Order = 7)]
    public class ToolBarcode : ToolBase
    {
        public ToolBarcode()
        {
            ToolCursor = Cursors.Cross;
        }


        public override void OnMouseDown(Designer designer, MouseEventArgs e)
        {
            AddNewObject(designer, new DrawBarcodes(e.X, e.Y));
        }

        public override void OnMouseMove(Designer designer, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //designer.Items[0].Move(e.X,e.Y);
                designer.Refresh();
                //designer.SelectedItem(designer.Items[0]);
            }
        }
    }
}
