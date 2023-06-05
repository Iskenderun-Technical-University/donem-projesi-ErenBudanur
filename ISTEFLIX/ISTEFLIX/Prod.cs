using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dizi_Film_Uyfulaması
{
    public class Prod
    {
        public Prod(String name, String pHOTOURL, String URL)
        {
            this.name = name;
            PHOTOURL = pHOTOURL;
            this.URL = URL;
        }
        public String name;
        public String PHOTOURL;
        public String URL;
    }
}
