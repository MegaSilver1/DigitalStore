document.addEventListener("DOMContentLoaded", function() {
    const userTable = document.getElementById('userTable').getElementsByTagName('tbody')[0];

    // Sample user data
    const users = [
        { id: 1, username: 'user1', email: 'user1@example.com', status: 'active' },
        { id: 2, username: 'user2', email: 'user2@example.com', status: 'banned' },
        { id: 3, username: 'user3', email: 'user3@example.com', status: 'active' }
    ];

    // Function to populate the user table
    function populateUserTable() {
        users.forEach(user => {
            const row = userTable.insertRow();

            row.insertCell(0).innerText = user.id;
            row.insertCell(1).innerText = user.username;
            row.insertCell(2).innerText = user.email;
            row.insertCell(3).innerText = user.status;
            
            const actionCell = row.insertCell(4);
            const banButton = document.createElement('button');
            banButton.innerText = user.status === 'active' ? 'Ban' : 'Unban';
            banButton.addEventListener('click', function() {
                toggleBanStatus(user.id);
            });
            actionCell.appendChild(banButton);
        });
    }

    // Function to toggle ban status of a user
    function toggleBanStatus(userId) {
        const user = users.find(u => u.id === userId);
        if (user) {
            user.status = user.status === 'active' ? 'banned' : 'active';
            updateUserTable();
        }
    }

    // Function to update the user table
    function updateUserTable() {
        // Clear current table rows
        userTable.innerHTML = '';
        // Repopulate table
        populateUserTable();
    }

    // Initially populate the user table
    populateUserTable();
});
