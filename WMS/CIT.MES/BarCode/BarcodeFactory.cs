using System;
using System.Collections.Generic;
using System.Text;

namespace CIT.MES.BarCode
{
    public class BarcodeFactory
    {
        public BarcodeFactory()
        { }

        public IBarcode CreateBarcode(string Name)
        {
            IBarcode MyBarcode = null;
            try
            {
                Type BarcodeType = Type.GetType(Name, true);
                MyBarcode = (IBarcode)Activator.CreateInstance(BarcodeType);
            }
            catch (TypeLoadException)
            {
                System.Windows.Forms.MessageBox.Show("条码加载失败!" + Name, "WormSoft Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return MyBarcode;

        }

        public IBarcode CreateBarcode(string Name,params object[] args)
        {
            IBarcode MyBarcode = null;
            try
            {
                Type btype = Type.GetType(Name, true);
                MyBarcode = (IBarcode)Activator.CreateInstance(btype,args);
            }
            catch (TypeLoadException)
            {
                System.Windows.Forms.MessageBox.Show("条码加载失败!" + Name, "WormSoft Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return MyBarcode;

        }
    }
}
