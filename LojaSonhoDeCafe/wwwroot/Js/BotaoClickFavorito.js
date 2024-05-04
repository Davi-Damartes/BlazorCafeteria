window.mudarCorButao = function (produtoId, isFavorito) {
    var btn = document.getElementById('btn-' + produtoId);
    var icone = btn.querySelector('.icone-coracao');

    if (isFavorito) {
        icone.style.color = 'red';
    }
    else {
        icone.style.color = 'black';
    }
};


