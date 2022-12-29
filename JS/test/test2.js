var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
const requestURL = 'https://cabinet.ssau.ru/login'

function sendRequest(method, url, body = null) {
  return new Promise((resolve, reject) => {
    const xhr = new XMLHttpRequest()

    xhr.open(method, url)

    //xhr.responseType = 'json'
    xhr.setRequestHeader('Content-Type', 'application/json;charset=utf-8')

    xhr.onload = () => {
        resolve(xhr.response)
    }

    xhr.onerror = () => {
        resolve(xhr.response)
    }

    xhr.send(JSON.stringify(body))
  })
}

sendRequest('GET', requestURL)
  .then(data => console.log(data))
  .catch(err => console.log(err))


sendRequest('POST', requestURL, body)
  .then(data => console.log(data))
  .catch(err => console.log(err))