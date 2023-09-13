
function httpGet() {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", "https://api-traveller.azurewebsites.net/Hoteis/PorNome?cidade=sa", false); // false for synchronous request
    xmlHttp.send(null);
    console.log(xmlHttp.responseText);

    let hoteis = JSON.parse(xmlHttp.responseText);

    for (let i = 0; i < hoteis.length; i++) 
    {
        //     var label = document.createElement("label");
        //     label.innerHTML = hoteis[i].nome;
        // let div = document.createElement("div");
        // div.innerHTML = hoteis[i].nome;
        // div.appendChild(label);
        // document.getElementById("cardHotel").appendChild(div);
        //     <div class="card">
        //     <img src="./assets/hotel.jpg" class="card-img-top" alt="...">
        //     <div class="card-body">
        //         <p class="card-text">São Paulo</p>
        //         <h5 class="card-title">Hotel Lorem Ipsum</h5>
        //         <p class="card-text">Diárias a partir de <span class="preco">R$154</span></p>
        //         <a href="#" class="btn btn-outline-secondary">Ver hotel</a>
        //     </div>
        // </div>

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

        // let cardBody = document.createElement("div");
        // cardBody.className = "card-body";
        // cardBody.id = "cardBody" + i;

        // let cardText = document.createElement("p");

        // document.getElementById("cardBody" + i).appendChild(cardText);
        // document.getElementById("card" + i).appendChild(cardBody + i);
        // document.getElementById("cardHotel").appendChild(card + i);
        
        // const box = document.createElement("div");
        // box.id = "box";
        // document.body.appendChild(box);

        // const button = document.createElement("button");
        // button.innerText = "Button";
        // button.id = "button-1";
        // box.appendChild(button);

    }

    return xmlHttp.responseText;

}
window.onload = httpGet();
