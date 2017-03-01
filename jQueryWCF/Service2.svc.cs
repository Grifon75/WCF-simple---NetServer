using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace jQueryWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service2" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service2.svc или Service2.svc.cs в обозревателе решений и начните отладку.

    //Создаем реализацию серверной службы для приема данных от клиентской .Net-службы и записи их в глобальный объект
    //Устанавливаем совместимость службы с приложением Asp.Net
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service2 : IService2
    {
        public Service2()
        {
            //При запуске службы инициализируем поле глобального объекта пустой коллекцией
            //Globals.mPersonsList = new List<PersonFromClient>();
        }

        //Реализация контракта операции
        public int addPerson(XElement _person)
        {
            //Создаем сериализатор
            var serializer = new XmlSerializer(typeof(PersonFromClient));
            //Десериализуем данные из типа XElement в тип PersonFromClient
            PersonFromClient person = (PersonFromClient)serializer.Deserialize(_person.CreateReader());
            //Добавляем полученный объект с данными от клиента в коллекцию глобального объекта
            Globals.mPersonsList.Add(person);
            //Возвращаем клиенту 0 как подтверждение успешного выполнения операции
            return 0;
        }
    }
}
