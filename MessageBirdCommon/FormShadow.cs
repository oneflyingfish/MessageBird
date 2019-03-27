using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MessageBirdCommon
{
    public static class FormShadow
    {
        //定义外部导入
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 设置阴影函数
        /// </summary>
        /// <param name="form"></param>
        public static void SetShadow(Form form)
        {
            SetClassLong(form.Handle, GCL_STYLE, GetClassLong(form.Handle, GCL_STYLE) | CS_DropSHADOW);
        }

        //下面为实现阴影的常量
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);

    }
}
