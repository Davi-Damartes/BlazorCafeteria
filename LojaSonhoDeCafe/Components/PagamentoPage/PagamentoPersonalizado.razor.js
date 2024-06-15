export function aplicarEstilos(divIdSelecionada, divIdOutra) {
    const divSelecionada = document.getElementById(divIdSelecionada);
    const divOutra = document.getElementById(divIdOutra);

    if (divSelecionada && divOutra) {
        const btnSelecionada = divSelecionada.querySelector('.btn-outline-danger');
        const btnOutra = divOutra.querySelector('.btn-outline-danger');

        if (btnSelecionada) {
            btnSelecionada.style.transition = 'background-color 0.2s ease';
            btnSelecionada.style.backgroundColor = 'var(--bs-danger)';
            btnSelecionada.style.color = 'white';
        }

        if (btnOutra) {
            btnOutra.style.transition = 'color 0.2s ease';
            btnOutra.style.color = 'white';
        }
    } else {
        console.error('Elementos não encontrados:', divIdSelecionada, divIdOutra);
    }
}