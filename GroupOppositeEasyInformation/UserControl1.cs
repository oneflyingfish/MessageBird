using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupOppositeEasyInformation
{
    public partial class GroupOppositeEasyInformation: UserControl
    {
        public GroupOppositeEasyInformation()
        {
            InitializeComponent();
        }

        public void SetInformation(string account,string userName,Bitmap userImage)
        {
            this.AccountLabel.Text = "ID："+account;
            this.UserNameLabel.Text ="昵称："+ userName;
            this.ImagePictureBox.BackgroundImage =userImage;
        }
    }
}
