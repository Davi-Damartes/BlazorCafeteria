const btn = document.querySelector('.btn');

btn.addEventListener('click', () => {

    btn.style.backgroundColor = '#ffac09';
    btn.style.boxShadow = '0 0 40px #ffac09';
    btn.style.transition = '.5s ease';
});

//function TornaBotaoAtualizarQuantidadeVisivel(id, visible) {

//    const atualizaQuantidadeButton = document.querySelector("button[data-itemId='" + id + "']");

//    if (visible == true) {
//        atualizaQuantidadeButton.style.display = "inline-block";
//    }
//    else {
//        atualizaQuantidadeButton.style.display = "none";
//    }
//}


window.MudarCorDoBotaoJS = (produtoId, produtoFavorito) => {
    var botao = document.getElementById("botao_" + produtoId);

    if (produtoFavorito == true) {
        botao.style.backgroundColor = "red";
    }
    else (produtoFavorito == false)

    {
        botao.style.backgroundColor = "gray";
    }
};