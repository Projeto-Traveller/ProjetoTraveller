
function httpGet() {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", "https://localhost:7142/Hoteis/PorNome?cidade=sa", false); // false for synchronous request
    xmlHttp.send(null);
    console.log(xmlHttp.responseText);

    let hoteis = JSON.parse(xmlHttp.responseText);

    for (let i = 0; i <= hoteis.length; i++) {
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
        let divCard = document.createElement("div");
        divCard.className = "card";
        divCard.id = "card" + i;

        let cardBody = document.createElement("div");
        cardBody.className = "card-body";
        cardBody.id = "cardBody" + i;

        let cardText = document.createElement("p");

        document.getElementById("cardBody" + i).appendChild(cardText);
        document.getElementById("card" + i).appendChild(cardBody + i);
        document.getElementById("cardHotel").appendChild(card + i);
        
        const box = document.createElement("div");
        box.id = "box";
        document.body.appendChild(box);

        const button = document.createElement("button");
        button.innerText = "Button";
        button.id = "button-1";
        box.appendChild(button);

    }

    return xmlHttp.responseText;

}
window.onload = httpGet();
