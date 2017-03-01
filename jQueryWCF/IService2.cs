using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace jQueryWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService2" в коде и файле конфигурации.

    //Создаем контракт серверной службы для приема данных от клиентской .Net-службы и записи их в глобальный объект
    [ServiceContract]
    public interface IService2
    {
        //Создаем контракт операции приема и сохранения данных
        [OperationContract]
        int addPerson(XElement _personXElement);
    }
}
