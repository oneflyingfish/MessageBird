using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBirdCommonClass;
using MessageBirdCommon;

namespace ShowSearchForm
{
    public partial class ShowSearchForm: UserControl
    {
        public ShowSearchForm()
        {
            InitializeComponent();
            this.RequestChatEvent += (o) => { };
        }

        /// <summary>
        /// 清空控件
        /// </summary>
        public void ClearControls()
        {
            int times = this.Controls.Count;
            for (int i=0;i<times;i++)
            {
                this.Controls.RemoveAt(0);
            }
        }

        ///// <summary>
        ///// 添加信息
        ///// </summary>
        ///// <param name="baseInformation"></param>
        ///// <param name="title"></param>
        //public void AddControlsObjectToPanel(List<GroupShowForm.GroupShowForm> baseInformation, string title = "")
        //{
        //    if (baseInformation == null)
        //    {
        //        //没有信息
        //        return;
        //    }

        //    if(baseInformation.Count<1)
        //    {
        //        return;
        //    }

        //    for (int i = 0; i < baseInformation.Count; i++)
        //    {
        //        this.Controls.Add(baseInformation[i]);
        //    }

        //    //添加模块标记
        //    if (title != "")
        //    {
        //        SpacerForm.SpacerForm titleSpacerForm = new SpacerForm.SpacerForm(title);
        //        titleSpacerForm.Dock = DockStyle.Top;
        //        this.Controls.Add(titleSpacerForm);
        //    }
        //}

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="baseInformation"></param>
        /// <param name="title"></param>
        public void AddControlsToPanel(List<BaseInformation> baseInformation, string title="")
        {
            if(baseInformation==null || baseInformation.Count<1)
            {
                //没有信息
                return;
            }

            for(int i=0;i<baseInformation.Count;i++)
            {
                BaseInformation info = baseInformation[i];
                GroupShowForm.GroupShowForm groupShowForm = new GroupShowForm.GroupShowForm();
                groupShowForm.SetInformation(info.Kind, info.UserName, info.Account, info.UserImage, info.IsOnline);
                groupShowForm.Visible = true;
                groupShowForm.Dock = DockStyle.Top;
                groupShowForm.DoubleClickEvent += GroupShowForm_DoubleClick;
                groupShowForm.MouseRightClick.Items.RemoveAt(3);
                groupShowForm.MouseRightClick.Items.RemoveAt(2);
                groupShowForm.MouseRightClick.Items.RemoveAt(1);
                this.Controls.Add(groupShowForm);
            }

            //添加模块标记
            if(title!="")
            {
                SpacerForm.SpacerForm titleSpacerForm = new SpacerForm.SpacerForm(title);
                titleSpacerForm.Dock = DockStyle.Top;
                this.Controls.Add(titleSpacerForm);
            }
        }

        /// <summary>
        /// 触发聊天请求时上抛
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_DoubleClick(object sender, EventArgs e)
        {
            RequestChatEvent(sender);
        }

        /// <summary>
        /// 上抛聊天事件
        /// </summary>
        public event Action<object> RequestChatEvent;
    }
}
