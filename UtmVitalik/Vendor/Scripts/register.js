document.getElementById('registerForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const username = document.getElementById('username').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    const errorMessage = document.getElementById('errorMessage');

    if (username === '' || email === '' || password === '' || confirmPassword === '') {
        errorMessage.textContent = 'Все поля должны быть заполнены.';
        errorMessage.style.display = 'block';
    } else if (password !== confirmPassword) {
        errorMessage.textContent = 'Пароли не совпадают.';
        errorMessage.style.display = 'block';
    } else if (username.length < 3 || password.length < 6) {
        errorMessage.textContent = 'Имя пользователя должно содержать не менее 3 символов, а пароль не менее 6 символов.';
        errorMessage.style.display = 'block';
    } else {
        errorMessage.style.display = 'none';
        // Здесь можно добавить код для отправки данных на сервер
        alert('Успешная регистрация');
    }
});
