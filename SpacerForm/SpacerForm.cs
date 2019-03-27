using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpacerForm
{
    public partial class SpacerForm: UserControl
    {
        public SpacerForm(string text="")
        {
            InitializeComponent();
            this.label.Text = text;
        }
    }
}
