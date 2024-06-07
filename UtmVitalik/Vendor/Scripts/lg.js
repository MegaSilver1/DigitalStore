document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();
    
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const errorMessage = document.getElementById('errorMessage');
    
    if (username === '' || password === '') {
        errorMessage.textContent = 'Все поля должны быть заполнены.';
        errorMessage.style.display = 'block';
    } else if (username.length < 3 || password.length < 6) {
        errorMessage.textContent = 'Имя пользователя должно содержать не менее 3 символов, а пароль не менее 6 символов.';
        errorMessage.style.display = 'block';
    } else {
        errorMessage.style.display = 'none';
        // Здесь можно добавить код для отправки данных на сервер
        alert('Успешный вход');
    }
});
