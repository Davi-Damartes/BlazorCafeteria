export function escolherOpcaoPagamento() {
    const divPagamentoCartao = document.getElementById('divPagamentoCartao');
    const divPagamentoDinheiro = document.getElementById('divPagamentoDinheiro');

    function handleDivClick(event) {
        divPagamentoCartao.classList.remove('active');
        divPagamentoDinheiro.classList.remove('active');



        divPagamentoCartao.onclick()
        {
            var labelPag1 = divPagamentoCartao.querySelector('label');
            labelPag1.style.backgroundColor = 'red';
        

            var labelPag1 = divPagamentoCartao.querySelector('label');
            labelPag1.style.backgroundColor = 'green';
        }

        event.currentTarget.classList.add('active');

        const inputRadio = event.currentTarget.querySelector('.btn-check');
        inputRadio.checked = true;

        if (event.currentTarget === divPagamentoCartao) {
            divPagamentoDinheiro.querySelector('label').classList.remove('text-white');
            divPagamentoCartao.querySelector('label').classList.add('text-white');
        } else if (event.currentTarget === divPagamentoDinheiro) {
            divPagamentoCartao.querySelector('label').classList.remove('text-white');
            divPagamentoDinheiro.querySelector('label').classList.add('text-white');
        }
    }

    divPagamentoCartao.addEventListener('click', handleDivClick);
    divPagamentoDinheiro.addEventListener('click', handleDivClick);
};
