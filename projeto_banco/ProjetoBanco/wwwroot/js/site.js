var cont = true;
const selectTipoChave = document.getElementById("tipoChavePix");
const divChave = document.getElementById("divChave");
const inputChave = document.getElementById("inputChave");

function mostrarSaldo() {
    let x = document.getElementById("saldo")

    if (x.type === "password") {
        document.getElementById("olho").className = "fa-solid fa-2x fa-eye-slash";
        x.type = "text";
    } else {
        document.getElementById("olho").className = "fa-solid fa-2x fa-eye";
        x.type = "password";
    }
}

selectTipoChave.addEventListener("change", () => {
    if (selectTipoChave.options[selectTipoChave.selectedIndex].value == 3) {
        inputChave.value = "0"
        divChave.className = "d-none"
    }
    else {
        divChave.className = "mb-3 input-group"
    }
})

function ErroValidacaoCpf() {

    const params = new URLSearchParams(window.location.search)
    for (const param of params) {
        document.getElementById("campoCpf").value = param[1]
    }

}
