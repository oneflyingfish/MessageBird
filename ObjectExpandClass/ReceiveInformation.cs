using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectExpandClass
{
    public class FunctionWords
    {
        public FunctionKind functionKind = FunctionKind.none;   //语句含义
        public List<string> stringList = new List<string>();    //块中字符串
        public List<Bitmap> bitmapList = new List<Bitmap>();    //块中图片
        public List<Byte[]> unknowList = new List<byte[]>();    //尚未定义的字节流，例如文件等
    }

    public class BlockInformation
    {
        public BlockKind blockKind = BlockKind.none;
        public int lengthOfValue = 0;
        public int lengthOfAll=0;
        public FunctionKind functionKind = FunctionKind.none;   //仅当 blockKind = BlockKind.Start有效

        public int LengthOfValue
        {
            get => lengthOfValue;
            set
            {
                lengthOfValue = value;
                this.lengthOfAll = lengthOfValue + 4;
            }
        }
    }
}
