//const sign_in_btn = document.querySelector("#sign-in-btn");
//const sign_up_btn = document.querySelector("#sign-up-btn");
//const container = document.querySelector(".container");

//sign_up_btn.addEventListener("click", () => {
//    container.classList.add("sign-up-mode");
//});

//sign_in_btn.addEventListener("click", () => {
//    container.classList.remove("sign-up-mode");
//});

//<script>
//    document.getElementById('btn-register').addEventListener('click', function() {
//        document.getElementById('view-login').style.opacity = 0;
//    document.getElementById('view-login').style.pointerEvents = 'none';
//    document.getElementById('view-register').style.opacity = 1;
//    document.getElementById('view-register').style.pointerEvents = 'auto';
//        });
//</script>

document.getElementById('a').addEventListener('click', function () {
    document.getElementById('IniciarSesion').style.opacity = 0;
    document.getElementById('IniciarSesion').style.pointerEvents = 'none';
    document.getElementById('Registrarse').style.opacity = 1;
    document.getElementById('Registrarse').style.pointerEvents = 'auto';
});

document.getElementById('a').addEventListener('click', function () {
    document.getElementById('Registrarse').style.opacity = 0;
    document.getElementById('Registrarse').style.pointerEvents = 'none';
    document.getElementById('IniciarSesion').style.opacity = 1;
    document.getElementById('IniciarSesion').style.pointerEvents = 'auto';
});