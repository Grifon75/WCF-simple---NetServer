//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading;
using System.Web;

namespace jQueryWCF
{
    /*Серверная ASP.NET-приложения для отправки данных Javascript-клиенту по его запросу при помощи AJAX*/
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        //Сложный контракт операции: отправляем Javascript-клиенту объект из коллекции, сериализованный в Json
        [WebGet(UriTemplate = "/person", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Person GetPerson()
        {
            //Имитируем длительное получение данных
            Thread.Sleep(1000);            
            //Создаем пустой объект контракта данных
            Person person = new Person();
            person.Size = 0;
            //Если коллекция объектов данных существует и она не пуста
            if (Globals.mPersonsList != null && Globals.mPersonsList.Count > 0 && Globals.count < Globals.mPersonsList.Count)
            {
                //    //Инициализируем поля объекта контракта данных
                person.Age = Globals.mPersonsList[Globals.count].Age;
                person.Name = Globals.mPersonsList[Globals.count].Name;
                person.isEmpty = false;
                person.Size = Globals.mPersonsList.Count;
                Globals.count++;
            }
            else
            {
                //Иначе устанавливаем флаг проверки на пустоту у объекта в true
                person.isEmpty = true;
                Globals.count = 0;
            }
            //Отправляем переменную объекта контракта данных Javascript-клиенту
            return person;
        }
        //Простой контракт операции: отправляем Javascript-клиенту строку, сериализованную в Json
        [WebGet(UriTemplate = "/hello", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string Hello()
        {
            Thread.Sleep(1000);
            return "Привет, Мир!";
        }
    }
    //Контракт данных для отправки Javascript-клиенту
    [DataContract]
    public class Person
    {
        [DataMember]
        public Int32 Age { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Int32 Size { get; set; }
        [DataMember]
        public Boolean isEmpty { get; set; }
    }
}
