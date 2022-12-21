using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleQuotationAutoRemover
{
    public partial class Form1 : Form
    {
        private string OldText;
        MenuItem DisableFunc = new MenuItem();

        public Form1()
        {
            InitializeComponent();
            MenuItem close = new MenuItem();
            close.Text = "閉じる";
            close.Click += (s, e) => Close();
            DisableFunc.Text = "無効化";
            DisableFunc.Click += (s, e) =>
                DisableFunc.Checked = !DisableFunc.Checked;
            Tbi.ContextMenu = new ContextMenu();
            Tbi.ContextMenu.MenuItems.Add(DisableFunc);
            Tbi.ContextMenu.MenuItems.Add(close);
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Hide();
            var newText = Clipboard.GetText();
            if (newText != OldText)
            {
                var r = new Regex("\"[A-Z]:\\\\*");
                if (r.IsMatch(newText) && !DisableFunc.Checked)
                {
                    newText = newText.Replace("\"", "");
                    Clipboard.SetText(newText);
                }
            }
            OldText = newText;
        }
    }
}
