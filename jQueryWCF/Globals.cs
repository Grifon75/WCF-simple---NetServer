using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQueryWCF
{
    //Глобальный объект, имитирующий постоянное хранилище данных
    //для сохранения объектов, полученных от .Net-клиента
    //и выдачи их Javascript-клиенту
    public static class Globals
    {
        public static List<PersonFromClient> mPersonsList;
        static Globals() {
            mPersonsList = new List<PersonFromClient>();
        }
        public static int count = 0;
    }
}