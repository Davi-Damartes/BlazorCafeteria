//window.mudarCorButao2 = function (produtoId, isFavorito)
//{
//    var btn = document.getElementById('btn-' + produtoId);
//    var icone = btn.querySelector('.icone-coracao');

//    if (isFavorito == true) {
//        icone.style.color = 'red';
//    }
//    else {
//        icone.style.color = 'black';
//    }
//};

export function mudarCorButao22(produtoId, isFavorito) {
    var btn = document.getElementById('btn-' + produtoId);
    var icone = btn.querySelector('.icone-coracao');

    if (isFavorito == true) {
        icone.style.color = 'red';
    }
    else {
        icone.style.color = 'black';
    }
}




