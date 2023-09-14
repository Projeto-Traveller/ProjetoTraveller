
let baseUrl = "https://api-traveller.azurewebsites.net/";
// let baseUrl = "https://localhost:7142/";
let apiKey = "AIzaSyDvchNONgwXYd119ZmjJKEZKhHuiTbR8zQ";

function getHoteis() {

    if (navigator.geolocation) {
        return navigator.geolocation.getCurrentPosition(requestApiHoteis);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}


function requestApiHoteis(position) {

    var xmlHttp = new XMLHttpRequest();

    let url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + position.coords.latitude + "," + position.coords.longitude + "&key=" + apiKey;

    xmlHttp.open("GET", url, false);
    xmlHttp.send(null);

    let data = JSON.parse(xmlHttp.responseText);
    let results = data.results;

    var country = null, countryCode = null, city = null, cityAlt = null;
    var c, lc, component;
    for (var r = 0, rl = results.length; r < rl; r += 1) {
        var result = results[r];

        if (!city && result.types[0] === 'locality') {
            for (c = 0, lc = result.address_components.length; c < lc; c += 1) {
                component = result.address_components[c];

                if (component.types[0] === 'locality') {
                    city = component.long_name;
                    break;
                }
            }
        }
        else if (!city && !cityAlt && result.types[0] === 'administrative_area_level_2') {
            for (c = 0, lc = result.address_components.length; c < lc; c += 1) {
                component = result.address_components[c];

                if (component.types[0] === 'administrative_area_level_1') {
                    cityAlt = component.long_name;
                    break;
                }
            }
        } else if (!country && result.types[0] === 'country') {
            country = result.address_components[0].long_name;
            countryCode = result.address_components[0].short_name;
        }

        if (city && country) {
            break;
        }


    }

    let location = {
        "city": city,
        "country": country,
        "countryCode": countryCode
    }

    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", baseUrl + "Hoteis/PorNome?cidade=" + location.city, false); // false for synchronous request
    xmlHttp.send(null);
    console.log(xmlHttp.responseText);

    let hoteis = JSON.parse(xmlHttp.responseText);

    for (let i = 0; i < hoteis.length; i++) {
        var cardHotel = document.getElementById("cardHotel");


        var divCard = document.createElement("div");
        divCard.className = "card";

        var image = document.createElement("img");
        image.src = hoteis[i].source;
        image.className = "card-img-top";

        divCard.appendChild(image);

        var divCardBody = document.createElement("div");
        divCardBody.className = "card-body";

        var cardText = document.createElement("div");
        cardText.innerText = hoteis[i].cidade;
        cardText.className = "card-text";

        divCardBody.appendChild(cardText);

        var cardTitle = document.createElement("h5");
        cardTitle.innerText = hoteis[i].nome;
        cardTitle.className = "card-title";

        divCardBody.appendChild(cardTitle);

        var cardText2 = document.createElement("div");
        cardText2.innerText = "Diárias a partir de ";
        cardText2.className = "card-text";

        var cardSpan = document.createElement("span");
        cardSpan.innerText = "R$" + hoteis[i].preco;
        cardSpan.className = "preco";

        cardText2.appendChild(cardSpan);
        divCardBody.appendChild(cardText2);

        var button = document.createElement("a");
        button.href = "#";
        button.className = "btn btn-outline-secondary";
        button.innerText = "Ver hotel";

        divCardBody.appendChild(button);

        divCard.appendChild(divCardBody);
        cardHotel.appendChild(divCard);
    }
    return xmlHttp.responseText
}

function getViagens() {
    var xmlHttp2 = new XMLHttpRequest();
    xmlHttp2.open("GET", baseUrl + "api/Viagens/", false); // false for synchronous request
    xmlHttp2.send(null);
    console.log(xmlHttp2.responseText);

    let viagens = JSON.parse(xmlHttp2.responseText);

    for (let x = 0; x < viagens.length; x++) {
        var cardViagem = document.getElementById("cardViagem");


        var divCard = document.createElement("div");
        divCard.className = "card";

        var image = document.createElement("img");
        image.src = "./assets/hotel.jpg";
        image.className = "card-img-top";

        divCard.appendChild(image);

        var divCardBody = document.createElement("div");
        divCardBody.className = "card-body";

        var cardText = document.createElement("div");
        cardText.innerText = viagens[x].origem;
        cardText.className = "card-text";

        divCardBody.appendChild(cardText);

        var cardTitle = document.createElement("h5");
        cardTitle.innerText = viagens[x].destino;
        cardTitle.className = "card-title";

        divCardBody.appendChild(cardTitle);

        var cardText2 = document.createElement("div");
        cardText2.innerText = "Passagens apartir de ";
        cardText2.className = "card-text";

        var cardSpan = document.createElement("span");
        cardSpan.innerText = "R$" + viagens[x].preco;
        cardSpan.className = "preco";

        cardText2.appendChild(cardSpan);
        divCardBody.appendChild(cardText2);

        var button = document.createElement("a");
        button.href = "#";
        button.className = "btn btn-outline-secondary";
        button.innerText = "Comprar Passagem";

        divCardBody.appendChild(button);

        divCard.appendChild(divCardBody);
        cardViagem.appendChild(divCard);
    }

    return xmlHttp2.responseText;
}

document.addEventListener('readystatechange', event => {
    switch (document.readyState) {
        case "loading":
            console.log("document.readyState: ", document.readyState,
                `- The document is still loading.`
            );
            break;
        case "interactive":
            console.log("document.readyState: ", document.readyState,
                `- The document has finished loading DOM. `,
                `- "DOMContentLoaded" event`
            );
            break;
        case "complete":
            afterLoadPage();
            console.log("document.readyState: ", document.readyState,
                `- The page DOM with Sub-resources are now fully loaded. `,
                `- "load" event`
            );
            break;
    }
});

function afterLoadPage() {
    getHoteis();
    getViagens();
}
