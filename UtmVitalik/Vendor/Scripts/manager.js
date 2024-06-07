document.addEventListener('DOMContentLoaded', () => {
    const gameForm = document.getElementById('gameForm');
    const gameList = document.getElementById('gameList');
    let editIndex = null;

    gameForm.addEventListener('submit', (e) => {
        e.preventDefault();
        const gameName = document.getElementById('gameName').value;
        const gamePrice = document.getElementById('gamePrice').value;

        if (editIndex !== null) {
            updateGame(editIndex, gameName, gamePrice);
        } else {
            addGame(gameName, gamePrice);
        }

        gameForm.reset();
    });

    function addGame(name, price) {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${name} - $${price}</span>
            <div class="actions">
                <button class="edit">Edit</button>
                <button class="delete">Delete</button>
            </div>
        `;
        gameList.appendChild(li);
        bindGameActions(li);
    }

    function updateGame(index, name, price) {
        const li = gameList.children[index];
        li.querySelector('span').textContent = `${name} - $${price}`;
        editIndex = null;
    }

    function bindGameActions(li) {
        li.querySelector('.edit').addEventListener('click', () => {
            const [name, price] = li.querySelector('span').textContent.split(' - $');
            document.getElementById('gameName').value = name;
            document.getElementById('gamePrice').value = price;
            editIndex = Array.from(gameList.children).indexOf(li);
        });

        li.querySelector('.delete').addEventListener('click', () => {
            li.remove();
        });
    }
});
