using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQueryWCF
{
    //Класс модели данных, принимаемых от .Net-клиента
    public class PersonFromClient
    {
        public Int32 Age { get; set; }
        public String Name { get; set; }
    }
}