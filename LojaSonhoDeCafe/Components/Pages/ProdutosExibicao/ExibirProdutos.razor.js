export function mudarCorButao(produtoid, isfavorito) {
    var btn = document.getelementbyid('btn-' + produtoid);
    var icone = btn.queryselector('.icone-coracao');

    if (isfavorito == true) {
        icone.style.color = 'red';
    }
    else {
        icone.style.color = 'black';
    }
}

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