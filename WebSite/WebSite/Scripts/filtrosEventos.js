
function bloquearEscrituraFecha(input) {
    input.addEventListener('keydown', function (e) {
        
        if (
            e.key === "Tab" || e.key === "Shift" ||
            e.key === "ArrowLeft" || e.key === "ArrowRight" ||
            e.key === "Delete" || e.key === "Backspace"
        ) {
            return;
        }
       
        e.preventDefault();
    });
    
    input.addEventListener('paste', function (e) {
        e.preventDefault();
    });
}

function toggleFechas() {
    var chk = document.getElementById(chkFiltrarFechaId);
    var fechaInicio = document.getElementById(txtFechaInicioId);
    var fechaFin = document.getElementById(txtFechaFinId);
    if (chk.checked) {
        fechaInicio.disabled = false;
        fechaFin.disabled = false;
    } else {
        fechaInicio.disabled = true;
        fechaFin.disabled = true;
        fechaInicio.value = '';
        fechaFin.value = '';
    }
    
    bloquearEscrituraFecha(fechaInicio);
    bloquearEscrituraFecha(fechaFin);
}

window.onload = function () {
    toggleFechas();
};