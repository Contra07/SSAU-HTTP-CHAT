// 1. Создаём новый объект XMLHttpRequest
//var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;

const requestURL = 'https://cabinet.ssau.ru';

var xhr = new XMLHttpRequest();

xhr.open('GET', requestURL);

xhr.onload = () => {
    console.log(xhr.getResponseHeader('Set-Cookie') + "\n\n" + xhr.status + "\n\n" + xhr.responseXML + "\n\n" + xhr.responseText);
}

xhr.send();


