/*Служба Javascript-клиента*/
var count = 0;
var end = false;
//Когда HTML-документ загружен в браузер
jQuery(document).ready(function () {
    //Добавляем на страницу два элемента
    loadingContent();
    //Отправляем AJAX-запрос сереврной службе, получаем от нее объект с данными и заменяем
    //этими данными содержимое ранее созданных двух элементов страницы
    getData("p#element");
});

function loadingContent() {
    var element = "<p id='element" + 0 + "'><img src='images/progress.gif'/>... </p><hr/>";
    jQuery("p#output").append(element);
}
$(function () {
    $("input#buttonNext").click(function () {
        getData("p#element");
    });
});

//var count = 0;
function getData(element) {

    var url = "/Service1.svc/";
    // Запрос AJAX на получение контента (JSON) с WCF REST сервиса
    // для .html()
    //" + "Имя: " + data.Name + " Возраст: " + data.Age + "
    jQuery.getJSON(url + "person", function (data) {
        if (!data.isEmpty) {
            //alert("Имя: " + data.Name + " Возраст: " + data.Age+" Рамер массива"+data.Size+" count"+count);
            if (count !== 0)
            {
                var elementP = "<p id='element" + count + "'></p><hr/>";
                jQuery("p#output").append(elementP);
            }
            jQuery(element + count).html("Имя: " + data.Name + " Возраст: " + data.Age + "<br />");
            count++;
        } else {
            if (count > 0) {
                var elementP_ = "<p id='element" + count + "'></p><hr/>";
                jQuery("p#output").append(elementP_);
                jQuery(element + count).html("Все данные считаны");
                count = 0;
            }
            else
            {
                jQuery(element + count).html("Нет данных");
            }
            $("input#buttonNext").hide();
        }
    });
    // Запрос AJAX на получение контента (string) с WCF REST сервиса
    //jQuery.getJSON(url + "hello", '{}', function (e) {
    //    jQuery(element + 1).html(e);
    //});
}