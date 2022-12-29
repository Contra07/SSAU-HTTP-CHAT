// 1. Создаём новый объект XMLHttpRequest
//var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;

const loginURL = 'https://cabinet.ssau.ru/login';
const requestURL = 'https://cabinet.ssau.ru/';
const chatsURL = 'https://cabinet.ssau.ru/api/chats/';
const logdata = {name:'2020-00983',password:'456852Sonic'};
const message = {message: 'Test message JS'};
var Cookie = 'Xuy';

sendRequest('GET',loginURL,null);
sendRequest('POST',loginURL,logdata);
var chats = JSON.parse(sendRequest('GET',chatsURL,null));
chats.forEach(element => {
    console.log(element.id + "  " + element.name);
});
sendRequest('POST',chatsURL + String(chats[0].id),message);


function sendRequest(method, URL, data)
{
    var xhr = new XMLHttpRequest();
    xhr.open(method,URL,false);
    xhr.setDisableHeaderCheck(true);
    xhr.setRequestHeader('Cookie', Cookie);
    if(data == null)
    {
        xhr.send();
    }
    else
    {
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.send(JSON.stringify(data));
    }
    Cookie = xhr.getResponseHeader('Set-Cookie');
    console.log( "URL:" + URL+ " Method " + method + "\nStatus:" + xhr.status+"\n");
    return xhr.responseText;
}
