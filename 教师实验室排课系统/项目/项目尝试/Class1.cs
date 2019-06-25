using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 项目尝试
{
    [Serializable]
    public class User
    {
        private string xgh;
        public string XGH
        {
            get { return xgh; }
            set { xgh = value; }
        }

        private string mm;
        public string MM
        {
            get { return mm; }
            set { mm = value; }
        }
    }
}
