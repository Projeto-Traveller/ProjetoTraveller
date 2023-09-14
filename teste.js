
function httpGet() {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", "https://api-traveller.azurewebsites.net/Hoteis/PorNome?cidade=sa", false); // false for synchronous request
    xmlHttp.send(null);
    console.log(xmlHttp.responseText);

    let hoteis = JSON.parse(xmlHttp.responseText);

    for (let i = 0; i < hoteis.length; i++) {
        var cardHotel = document.getElementById("cardHotel");


        var divCard = document.createElement("div");
        divCard.className = "card";

        var image = document.createElement("img");
        image.src = "./assets/hotel.jpg";
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
function httpGet2() {
    var xmlHttp2 = new XMLHttpRequest();
    xmlHttp2.open("GET", "https://localhost:7142/api/Viagens/PorNome?origem=sa", false); // false for synchronous request
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
window.onload = httpGet(),httpGet2();


